using AutoMapper;
using Baggr.Providers.BLL.IManager;
using Baggr.Providers.Common;
using Baggr.Providers.DAL;
using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.DTO.MylerzModels;
using Baggr.Providers.Entities.Entities;
using Baggr.Providers.Gateway.IAPIs;
using Baggr.Providers.IMP.ICompany;
using Baggr.Providers.IMP.IProvider;
using Baggr.Providers.IMP.Provider;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.BLL.Manager
{
    public class ShipmentManager : IShipmentManager
    {
        private readonly IProviderManager _providerManager;
        private readonly IAramexManager _aramexManager;
        private readonly IFedexManager _fedexManager;
        private readonly IMylerzManager _mylerzManager;
        private readonly IJTExpressManager _jTExpressManger;
        private readonly IMapper _mapper;
        private readonly IProvidersRepository<Shipment> _providersRepository;
        private readonly IProductManager _productManager;
        private readonly ICustomerManager _customerManager;
        public ShipmentManager(IProviderManager providerManager, IAramexManager aramexManager,
            IFedexManager fedexManager, IMylerzManager mylerzManager, IMapper mapper,
            IProvidersRepository<Shipment> providersRepository, IProductManager productManager, ICustomerManager customerManager, IJTExpressManager jTExpressManger)
        {
            _providerManager = providerManager;
            _aramexManager = aramexManager;
            _fedexManager = fedexManager;
            _mylerzManager = mylerzManager;
            _mapper = mapper;
            _providersRepository = providersRepository;
            _productManager = productManager;
            _customerManager = customerManager;
            _jTExpressManger = jTExpressManger;
        }
        public async Task<ResultModel<IEnumerable<GetQuoteDTO>>> GetQuote(string fromCity, string toCity, double weight)
        {
            var result = new List<GetQuoteDTO>();
            var providers = _providerManager.GetProviders();

            var fedexQuote = await _fedexManager.GetQuote(providers.Result, fromCity, toCity, weight);
            if (fedexQuote != null) result.Add(fedexQuote);

            var aramexQuote = await _aramexManager.GetQuote(providers.Result, fromCity, toCity, weight);
            if (aramexQuote != null) result.Add(aramexQuote);

            var mylerzQuote = await _mylerzManager.GetQuote(providers.Result, fromCity, toCity, weight);
            if (mylerzQuote != null) result.Add(mylerzQuote);

            return new ResultModel<IEnumerable<GetQuoteDTO>>(true, StatusMessage.Ok, result);

        }

        /*
         *   In MySql Must Insert Manually 
         *    
         *    Id      Key                 ProvideName     ProvideLogo     ProviderAnalyticsColour
         *    4      jtexpresskey      JtExpress           " "                  "orange"
         * 
         */
        public async Task<ResultModel<IEnumerable<ShipmentCreationResponseDTO>>> CreateShipments(ShipmentBulkDTO shipmentBulkDTO, Provider provider)
        {
            IEnumerable<ShipmentCreationResponseDTO> result = null;
            if (shipmentBulkDTO.ProviderKey == "fedexKey")
                result = await _fedexManager.CreateOrders(shipmentBulkDTO.Shipments, provider);
            if (shipmentBulkDTO.ProviderKey == "aramexKey")
                result = await _aramexManager.CreatePickupOrders(shipmentBulkDTO.Shipments, provider);
            if (shipmentBulkDTO.ProviderKey == "mylerzKey")
                result = await _mylerzManager.CreateOrders(shipmentBulkDTO.Shipments, provider);
            if (shipmentBulkDTO.ProviderKey == "jtexpresskey")
                result = await _jTExpressManger.CreateOrders(shipmentBulkDTO.Shipments, provider);
            await _productManager.DeductQuantities(shipmentBulkDTO.Shipments.SelectMany(s => s.shipmentProducts).ToList());

            var shipments = _mapper.Map<IEnumerable<ShipmentDTO>, IEnumerable<Shipment>>(shipmentBulkDTO.Shipments).ToList();
            for (int i = 0; i < shipments.Count; i++)
            {
                shipments[i].AWB = result.ToList()[i].AWB;
                shipments[i].Key = Guid.NewGuid().ToString();
                shipments[i].BiiCode = Guid.NewGuid().ToString();
                shipments[i].CreatedOn = DateTime.UtcNow;
                shipments[i].OrderReference = Helper.GenerateOrderRefrence();
                shipments[i].ProviderId = provider.Id;
            }

            await _providersRepository.Add(shipments);
            await _customerManager.CreateShipmentCustomers(shipmentBulkDTO);
            return new ResultModel<IEnumerable<ShipmentCreationResponseDTO>>(true, StatusMessage.Ok, result);
        }
        public async Task<ResultModel<String>> HideShipments(IEnumerable<string> shipmentkeys)
        {
            var shipments = _providersRepository.GetAll().Where(sh => shipmentkeys.Any(key => key == sh.Key)).ToList();
            foreach (Shipment sh in shipments)
                sh.IsHidden = true;
            await _providersRepository.Update(shipments);
            return new ResultModel<string>(true, StatusMessage.Ok, "Number of shipments affected "+shipments.Count());
        }
        public ResultModel<ShipmentsPageDTO> GetShipments(string merchantKey, string searchTerm, int PageSize, int PageNumber, DateTime ? from, DateTime ? to, Boolean? isFulfilled)
        {
            IQueryable<Shipment> Allshipments = _providersRepository.GetAll()
                .Include(sh => sh.Provider)
                .Include(sh => sh.ShipmentProducts)
                .ThenInclude(sp => sp.Product);

            Allshipments = Allshipments.Where(x =>
                (!x.IsHidden) &&
                (merchantKey == null || x.MerchantKey == merchantKey) &&
                (from == null || x.CreatedOn >= from) &&
                (to == null || x.CreatedOn <= to) &&
                (string.IsNullOrWhiteSpace(searchTerm) || x.CustomerPhoneNum.Contains(searchTerm) || x.AWB == searchTerm));
            Allshipments = Allshipments.OrderByDescending(x => x.CreatedOn);

            if (isFulfilled != null) PageSize = 300;

            var shipments = Allshipments
                 .Skip(PageSize * (PageNumber - 1))
                 .Take(PageSize);

            int TotalCount = Allshipments.Count();

            int PagesCount = (int)Math.Ceiling(TotalCount / ((double)PageSize == 0 ? 1 : (double)PageSize));
           
            var shipmentList = shipments.Any() ? AddShipmentStatus(shipments.ToList()).Result : new List<Shipment>();

            if (isFulfilled != null)
            {
                shipmentList = FilterByIsFulfilled(shipmentList, isFulfilled);
                TotalCount = shipmentList.Count();
            }
                ShipmentsPageDTO shipmentsPage = new ShipmentsPageDTO()
            {
                PagesCount = PagesCount,
                TotalCount = TotalCount,
                Shipments = _mapper.Map<IList<Shipment>, IList<ShipmentDTO>>(shipmentList)
            };
            return new ResultModel<ShipmentsPageDTO>(true, StatusMessage.Ok, shipmentsPage);
        }
        private IList<Shipment> FilterByIsFulfilled (IList<Shipment> shipments, Boolean? isFulfilled)
        {
            var deliveredStatus = new List<string>() { "delivered", "charges paid", "supporting document", "shipment update" };
            if(isFulfilled == true)
            return shipments.Where(sh => sh.LastStatus != null && deliveredStatus.Any(ds => sh.LastStatus.ToLower().Contains(ds))).ToList();
            return shipments.Where(sh => sh.LastStatus != null && !deliveredStatus.Any(ds => sh.LastStatus.ToLower().Contains(ds))).ToList();
        }
        private async Task<IList<Shipment>> AddShipmentStatus (IList<Shipment> shipments)
        {
            List<ShipmentTrackingDTO> shipmentTrackingResult = new List<ShipmentTrackingDTO>();
            
            var aramexAWBs = shipments.Where(sh => sh.Provider.Key == "aramexKey" && !String.IsNullOrEmpty(sh.AWB)).Select(sh => sh.AWB);
            if(aramexAWBs!=null && aramexAWBs.Any())
                 shipmentTrackingResult.AddRange( await _aramexManager.GetTrackingShipments(aramexAWBs));

            var fedexAWBs = shipments.Where(sh => sh.Provider.Key == "fedexKey" && !String.IsNullOrEmpty(sh.AWB)).Select(sh => sh.AWB);
            if (fedexAWBs != null && fedexAWBs.Any())
                shipmentTrackingResult.AddRange( await _fedexManager.GetTrackingShipments(fedexAWBs));

            var mylerzAWBs = shipments.Where(sh => sh.Provider.Key == "mylerzKey" && !String.IsNullOrEmpty(sh.AWB)).Select(sh => sh.AWB);
            if (mylerzAWBs != null && mylerzAWBs.Any())
                shipmentTrackingResult.AddRange(await _mylerzManager.GetTrackingShipments(mylerzAWBs));
            //select billcode not awb
            var JTExpressAWBs = shipments.Where(sh => sh.Provider.Key == "jtexpressKey" && !String.IsNullOrEmpty(sh.AWB)).Select(sh => sh.AWB);
            if (JTExpressAWBs != null && shipments.Any())
                shipmentTrackingResult.AddRange(await _jTExpressManger.GetTrackingShipments(JTExpressAWBs));

            foreach (Shipment sh in shipments)
                sh.LastStatus = shipmentTrackingResult?.Where(tr => tr.AWB == sh.AWB).FirstOrDefault()?.LastStatus;
            
            return shipments;
        }
        public async Task<ResultModel<GetPDFResponseDTO>> GetShipmentPDF(Shipment shipment)
        {
            GetPDFResponseDTO result = null;
            if (shipment.Provider.Key == "fedexKey")
                result = await _fedexManager.GetPDF(shipment.AWB);
            if (shipment.Provider.Key == "aramexKey")
                result = await _aramexManager.GetPDF(shipment.AWB);
            if (shipment.Provider.Key == "mylerzKey")
                result = await _mylerzManager.GetPDF(shipment.AWB);
            if (shipment.Provider.Key == "jtexpresskey")
                result = await _jTExpressManger.GetPDF(shipment.BiiCode);

            return new ResultModel<GetPDFResponseDTO>(true, StatusMessage.Ok, result);
        }
        public async Task<ResultModel<Shipment>> GetShipmentByKey(string shipmentKey, bool statusIncluded = true)
        {
         

            var shipment = await _providersRepository.GetAll()
               .Include(sh => sh.Provider)
               .ThenInclude(p => p.ProviderCities)
               .ThenInclude(pc => pc.City)
               .Where(sh => sh.Key == shipmentKey).FirstOrDefaultAsync();

            if (shipment == null)
                return new ResultModel<Shipment>(false, StatusMessage.NotFound);
            var shipments = new List<Shipment>() { shipment };
            var shipmentWithStatus = statusIncluded ? await AddShipmentStatus(shipments) : shipments;

            return new ResultModel<Shipment>(true, StatusMessage.Ok, shipmentWithStatus.FirstOrDefault());
        }

        public async Task<ResultModel<ShipmentDTO>> GetShipmentByKeyWithStatusLogs(string shipmentKey, bool statusIncluded = true)
        {
            var shipment = await _providersRepository.GetAll()
                .Include(sh => sh.Provider)
                .ThenInclude(p => p.ProviderCities)
                .ThenInclude(pc => pc.City)
                .Include(sh => sh.ShipmentProducts)
                .ThenInclude(sp => sp.Product)
                .Where(sh => sh.Key == shipmentKey).FirstOrDefaultAsync();

            if (shipment == null)
                return new ResultModel<ShipmentDTO>(false, StatusMessage.NotFound);

            var shipmentWithStatus = statusIncluded ? await AddShipmentStatusLogs(shipment) : _mapper.Map<ShipmentDTO>(shipment);
            
            return new ResultModel<ShipmentDTO>(true, StatusMessage.Ok, shipmentWithStatus);
        }

        private async Task<ShipmentDTO> AddShipmentStatusLogs(Shipment shipment)
        {
            List<ShipmentTrackingLogDto> shipmentTrackingResult = new List<ShipmentTrackingLogDto>();

            var aramexAWB = (shipment.Provider.Key == "aramexKey" && !String.IsNullOrEmpty(shipment.AWB)) ? shipment.AWB : null;
            if (aramexAWB != null)
            {
                shipmentTrackingResult.AddRange(await _aramexManager.GetTrackingShipmentLogs(aramexAWB));
                shipment.LastStatus = shipmentTrackingResult.OrderByDescending(x => x.ChangedDate).FirstOrDefault().StatusEnName;
            }

            var fedexAWB = (shipment.Provider.Key == "fedexKey" && !String.IsNullOrEmpty(shipment.AWB))?shipment.AWB:null;
            if (!string.IsNullOrEmpty(fedexAWB))
            {
                var fedexTrackingResult = (await _fedexManager.GetTrackingShipmentLogs(fedexAWB));
                shipmentTrackingResult.AddRange(fedexTrackingResult.Item1);
                shipment.LastStatus = fedexTrackingResult.Item2;
               
            }


            var mylerzAWB = (shipment.Provider.Key == "mylerzKey" && !String.IsNullOrEmpty(shipment.AWB))? shipment:null;
            if (mylerzAWB != null)
            {
                shipmentTrackingResult.AddRange(
                        await _mylerzManager.GetTrackingShipmentLogs(
                        new List<MylerzGetTrackingShipmentLogsBody>() { new MylerzGetTrackingShipmentLogsBody() { Barcode = shipment.AWB ,ReferenceNumber=shipment.AWB} }));
                shipment.LastStatus = shipmentTrackingResult.OrderByDescending(x => x.ChangedDate)
                                                            .FirstOrDefault().StatusEnName;


            }
            //select billcode not awb
            var JTExpressAWB = (shipment.Provider.Key == "jtexpressKey" && !String.IsNullOrEmpty(shipment.AWB)) ? shipment.AWB : null;
            if (aramexAWB != null)
            {
                shipmentTrackingResult.AddRange(await _jTExpressManger.GetTrackingShipmentLogs(aramexAWB));
                shipment.LastStatus = shipmentTrackingResult.OrderByDescending(x => x.ChangedDate).FirstOrDefault().StatusEnName;
            }

            var shipmentDto = _mapper.Map<ShipmentDTO>(shipment);
            shipmentDto.StatusLogs=shipmentTrackingResult;

            return shipmentDto;
        }


        
    }
}

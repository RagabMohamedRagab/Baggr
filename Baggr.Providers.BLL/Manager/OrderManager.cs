using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Baggr.Providers.DAL;
using Baggr.Providers.Entities.Entities;
using Baggr.Providers.BLL.IManager;
using Baggr.Providers.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;

namespace Baggr.Providers.BLL.Manager
{
    public class OrderManager : IOrderManager
    {

        private readonly IProvidersRepository<Order> _providersRepository;
        private readonly IMapper _mapper;
        public OrderManager (IProvidersRepository<Order> providersRepository, IMapper mapper)
        {
            _providersRepository = providersRepository;
            _mapper = mapper;
        }
        public async Task<ResultModel<string>> CreateOrders (IList<Order> orders)
        {   
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Key != null)
                    await DeleteOrderByKey(orders[i].Key);

                orders[i].Key = Guid.NewGuid().ToString();
             
          
                orders[i].CreatedOn = DateTime.UtcNow;
                orders[i].OrderReference = Helper.GenerateOrderRefrence();
                
            }
            await _providersRepository.Add(orders);
            return new ResultModel<string>( true, StatusMessage.Ok, "Orders Craeted" );
        }
        
        public ResultModel<OrdersPageDTO> GetOrders(string merchantKey, string searchTerm, int PageSize, int PageNumber, DateTime? from, DateTime? to, bool? isPayed)
        {
            IQueryable<Order> AllOrders = _providersRepository.GetAll()
                .Include(sh => sh.OrderProducts)
                .ThenInclude(sp => sp.Product);

            AllOrders = AllOrders.Where(x =>
                (!x.IsDeleted) &&
                (merchantKey == null || x.MerchantKey == merchantKey) &&
                (from == null || x.CreatedOn >= from) &&
                (to == null || x.CreatedOn <= to) &&
                (isPayed == null || x.IsPayed == isPayed) &&
                (string.IsNullOrWhiteSpace(searchTerm) || x.CustomerPhoneNum.Contains(searchTerm) ));
            AllOrders = AllOrders.OrderByDescending(x => x.CreatedOn);


            var orders = AllOrders
                 .Skip(PageSize * (PageNumber - 1))
                 .Take(PageSize);

            int TotalCount = AllOrders.Count();

            int PagesCount = (int)Math.Ceiling(TotalCount / ((double)PageSize == 0 ? 1 : (double)PageSize));

            OrdersPageDTO ordersPage = new OrdersPageDTO()
            {
                PagesCount = PagesCount,
                TotalCount = TotalCount,
                Orders = _mapper.Map<IList<Order>, IList<OrderDTO>>(orders.ToList())
            };
            return new ResultModel<OrdersPageDTO>(true, StatusMessage.Ok, ordersPage);
        }
        public async Task<ResultModel<Order>> GetOrderByKey(string orderKey)
        {
            var order = await _providersRepository.GetAll()
               .Include(sh => sh.OrderProducts)
               .ThenInclude(p => p.Product)
               .Where(sh => sh.Key == orderKey).FirstOrDefaultAsync();

            if (order == null)
                return new ResultModel<Order>(false, StatusMessage.NotFound);

            return new ResultModel<Order>(true, StatusMessage.Ok, order);
        }
        public async Task<ResultModel<string>> DeleteOrderByKey(string orderKey)
        {
            var order = await _providersRepository.GetAll()
               .Where(sh => sh.Key == orderKey).FirstOrDefaultAsync();

            if (order == null)
                return new ResultModel<string>(false, StatusMessage.NotFound);

            order.IsDeleted = true;
            _providersRepository.Update(order);

            return new ResultModel<string>(true, StatusMessage.Ok, "Order Deleted Succesfully");
        }
        public async Task<ResultModel<string>> DeleteOrderByKeys(IList<string> orderKeys)
        {
            var orders = await _providersRepository.GetAll()
               .Where(sh => orderKeys.Any(ok => ok == sh.Key)).ToListAsync();

            if (orders == null)
                return new ResultModel<string>(false, StatusMessage.NotFound);
            for(int i = 0; i < orders.Count; i++)
                orders[i].IsDeleted = true;

            await _providersRepository.Update(orders);

            return new ResultModel<string>(true, StatusMessage.Ok, "Orders Deleted Succesfully");
        }
        public async Task MarkOrderPayed(string orderRef)
        {
            var order = await _providersRepository.GetAll()
               .Where(sh => sh.OrderReference == orderRef).FirstOrDefaultAsync();

            order.IsPayed = true;
            _providersRepository.Update(order);
        }
    }
}

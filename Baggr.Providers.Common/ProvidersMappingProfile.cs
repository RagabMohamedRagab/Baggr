using AutoMapper;
using Baggr.Providers.DTO.AramexModels;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.DTO.FedexModels;
using Baggr.Providers.DTO.J_TExpressModels;
using Baggr.Providers.DTO.MylerzModels;
using Baggr.Providers.Entities.Entities;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baggr.Providers.Common
{
    public class ProvidersMappingProfile : Profile
    {
        public ProvidersMappingProfile(IConfiguration configuration)
        {
            
            /////////////////////FedexMapping//////////////////////
            CreateMap<FedexShipmentCreationBody, FedexPickupCreationBody>()
                .ForPath(dest => dest.BookingData.BookingCity, src => src.MapFrom(x => x.AirwayBillData.Origin))
                .ForPath(dest => dest.BookingData.SendersAddress1, src => src.MapFrom(x => x.AirwayBillData.SendersAddress1))
                .ForPath(dest => dest.BookingData.SendersAddress2, src => src.MapFrom(x => x.AirwayBillData.SendersAddress2))
                .ForPath(dest => dest.BookingData.SendersCity, src => src.MapFrom(x => x.AirwayBillData.Origin))
                .ForPath(dest => dest.BookingData.SendersCompany, src => src.MapFrom(x => x.AirwayBillData.SendersCompany))
                .ForPath(dest => dest.BookingData.SendersContactPerson, src => src.MapFrom(x => x.AirwayBillData.SendersContactPerson))
                .ForPath(dest => dest.BookingData.SendersEmail, src => src.MapFrom(x => x.AirwayBillData.SendersEmail))
                .ForPath(dest => dest.BookingData.SendersMobile, src => src.MapFrom(x => x.AirwayBillData.SendersMobile))
                .ForPath(dest => dest.BookingData.SendersPhone, src => src.MapFrom(x => x.AirwayBillData.SendersPhone))
                .ForPath(dest => dest.BookingData.BookingCity, src => src.MapFrom(x => x.AirwayBillData.Origin))
                .ForPath(dest => dest.BookingData.BookingCompanyName, src => src.MapFrom(x => x.AirwayBillData.SendersCompany))
                .ForPath(dest => dest.BookingData.BookingContactPerson, src => src.MapFrom(x => x.AirwayBillData.SendersContactPerson))
                .ForPath(dest => dest.BookingData.BookingCreatedBy, src => src.MapFrom(x => x.AirwayBillData.SendersContactPerson))
                .ForPath(dest => dest.BookingData.BookingEmail, src => src.MapFrom(x => x.AirwayBillData.SendersEmail))
                .ForPath(dest => dest.BookingData.BookingMobileNo, src => src.MapFrom(x => x.AirwayBillData.SendersMobile))
                .ForPath(dest => dest.BookingData.BookingPhoneNo, src => src.MapFrom(x => x.AirwayBillData.SendersPhone))
                .ForPath(dest => dest.BookingData.ShipmentReadyDate, src => src.MapFrom(x => DateTime.Now.ToString("MM/dd/yyyy")))
                .ForMember(dest => dest.Password, src => src.MapFrom(x => configuration["GateWay:Fedex:Password"]))
                .ForMember(dest => dest.UserName, src => src.MapFrom(x => configuration["GateWay:Fedex:UserName"]))
                .ForMember(dest => dest.AccountNo, src => src.MapFrom(x => configuration["GateWay:Fedex:AccountNo"]));

            CreateMap<ShipmentDTO, FedexShipmentCreationBody>()
                .ForPath(dest => dest.AirwayBillData.ReceiversCompany, src => src.MapFrom(x => Guid.NewGuid().ToString()))
                .ForPath(dest => dest.AirwayBillData.ReceiversAddress1, src => src.MapFrom(x => x.CustomerAddress))
                .ForPath(dest => dest.AirwayBillData.ReceiversCity, src => src.MapFrom(x => x.CustomerCity))
                .ForPath(dest => dest.AirwayBillData.ReceiversContactPerson, src => src.MapFrom(x => x.CustomerName))
                .ForPath(dest => dest.AirwayBillData.ReceiversEmail, src => src.MapFrom(x => x.CustomerEmail))
                .ForPath(dest => dest.AirwayBillData.ReceiversMobile, src => src.MapFrom(x => x.CustomerPhoneNum))
                .ForPath(dest => dest.AirwayBillData.SendersAddress1, src => src.MapFrom(x => x.MerchantAddress))
                .ForPath(dest => dest.AirwayBillData.SendersCity, src => src.MapFrom(x => x.MerchantCity))
                .ForPath(dest => dest.AirwayBillData.SendersContactPerson, src => src.MapFrom(x => x.MerchantName))
                .ForPath(dest => dest.AirwayBillData.SendersCompany, src => src.MapFrom(x => x.MerchantCompanyName))
                .ForPath(dest => dest.AirwayBillData.SendersEmail, src => src.MapFrom(x => x.MerchantEmail))
                .ForPath(dest => dest.AirwayBillData.SendersPhone, src => src.MapFrom(x => x.MerchantPhoneNum))
                .ForPath(dest => dest.AirwayBillData.CODAmount, src => src.MapFrom(x => x.TotalAmountShouldBeCollected))
                .ForPath(dest => dest.AirwayBillData.Weight, src => src.MapFrom(x => x.Weight))
                .ForPath(dest => dest.AirwayBillData.SpecialInstruction, src => src.MapFrom(x => x.Note))
                .ForPath(dest => dest.AirwayBillData.Origin, src => src.MapFrom(x => x.MerchantCity))
                .ForPath(dest => dest.AirwayBillData.Destination, src => src.MapFrom(x => x.CustomerCity))
                .ForPath(dest => dest.AirwayBillData.ShipperReference, src => src.MapFrom(x => x.MerchantKey))
                .ForPath(dest => dest.AirwayBillData.NumberofPeices, src => src.MapFrom(x=> x.NumberofPeices))
                .ForPath(dest => dest.AirwayBillData.GoodsDescription, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.Password, src => src.MapFrom(x => configuration["GateWay:Fedex:Password"]))
                .ForMember(dest => dest.UserName, src => src.MapFrom(x => configuration["GateWay:Fedex:UserName"]))
                .ForMember(dest => dest.AccountNo, src => src.MapFrom(x => configuration["GateWay:Fedex:AccountNo"]));
            CreateMap<FedexShipmentCreationResponse, ShipmentCreationResponseDTO>()
                .ForMember(dest => dest.AWB, src => src.MapFrom(x => x.AirwayBillNumber));
            CreateMap<FedexGetPDFResponse, GetPDFResponseDTO>()
                .ForMember(dest => dest.PDF, src => src.MapFrom(x => x.ReportDoc))
                .ForMember(dest => dest.Type, src => src.MapFrom(x => "Base64"));
            CreateMap<FedexTrackShipmentResponse, ShipmentTrackingDTO>()
                .ForMember(dest => dest.LastStatus, src => src.MapFrom(x => x.AirwayBillTrackList.FirstOrDefault().LastStatus))
                .ForMember(dest => dest.AWB, src => src.MapFrom(x => x.AirwayBillTrackList.FirstOrDefault().AirWayBillNo));
            CreateMap<FedexTrackingLogDetails, ShipmentTrackingLogDto>()
              .ForMember(dest => dest.StatusEnName, src => src.MapFrom(x => x.Remarks))
              .ForMember(dest => dest.ChangedDate, src => src.MapFrom(x =>  new DateTime(x.ActivityDate.Year, 
                                                         x.ActivityDate.Month, x.ActivityDate.Day, 
                      x.ActivityTime.Hour, x.ActivityTime.Minute, x.ActivityTime.Second).AddHours(-2)                  
                  ));

            //////////////////////////AramexMapping///////////////////////////////
            CreateMap<ShipmentDTO, AramexShipment>()
                .ForPath(dest => dest.Consignee.PartyAddress.Line1, src => src.MapFrom(x => x.CustomerAddress))
                .ForPath(dest => dest.Consignee.PartyAddress.City, src => src.MapFrom(x => x.CustomerCity))
                .ForPath(dest => dest.Consignee.Contact.PersonName, src => src.MapFrom(x => x.CustomerName))
                .ForPath(dest => dest.Consignee.Contact.CompanyName, src => src.MapFrom(x => x.CustomerName))
                .ForPath(dest => dest.Consignee.Contact.EmailAddress, src => src.MapFrom(x => x.CustomerEmail))
                .ForPath(dest => dest.Consignee.Contact.PhoneNumber1, src => src.MapFrom(x => x.CustomerPhoneNum))
                .ForPath(dest => dest.Consignee.Contact.CellPhone, src => src.MapFrom(x => x.CustomerPhoneNum))
                .ForPath(dest => dest.Shipper.PartyAddress.Line1, src => src.MapFrom(x => x.MerchantAddress))
                .ForPath(dest => dest.Shipper.PartyAddress.City, src => src.MapFrom(x => x.MerchantCity))
                .ForPath(dest => dest.Shipper.Contact.CompanyName, src => src.MapFrom(x => x.MerchantCompanyName))
                .ForPath(dest => dest.Shipper.Contact.PersonName, src => src.MapFrom(x => x.MerchantName))
                .ForPath(dest => dest.Shipper.Contact.EmailAddress, src => src.MapFrom(x => x.MerchantEmail))
                .ForPath(dest => dest.Shipper.Contact.PhoneNumber1, src => src.MapFrom(x => x.MerchantPhoneNum))
                .ForPath(dest => dest.Shipper.Contact.CellPhone, src => src.MapFrom(x => x.MerchantPhoneNum))
                .ForPath(dest => dest.Details.CashOnDeliveryAmount.Value, src => src.MapFrom(x => x.TotalAmountShouldBeCollected))
                .ForPath(dest => dest.Details.Services, src => src.MapFrom(x => x.TotalAmountShouldBeCollected > 0 ? "CODS" : ""))
                .ForPath(dest => dest.Details.ActualWeight.Value, src => src.MapFrom(x => x.Weight))
                .ForPath(dest => dest.Comments, src => src.MapFrom(x => x.Note))
                .ForPath(dest => dest.Details.NumberOfPieces, src => src.MapFrom(x => x.NumberofPeices))
                .ForPath(dest => dest.Details.DescriptionOfGoods, src => src.MapFrom(x => x.Description))
                .ForPath(dest => dest.Shipper.AccountNumber, src => src.MapFrom(x => configuration["GateWay:Aramex:AccountNo"]));
           
            
            
            
            
            CreateMap<AramexShipmentResponse, ShipmentCreationResponseDTO>()
                .ForMember(dest => dest.AWB, src => src.MapFrom(x => x.ID));
            CreateMap<AramexGetPDFResponse, GetPDFResponseDTO>()
                .ForMember(dest => dest.PDF, src => src.MapFrom(x =>Convert.ToBase64String(x.ShipmentLabel.LabelFileContents)))
                .ForMember(dest => dest.Type, src => src.MapFrom(x => "Base64"));
            CreateMap<AramexTrackShipment, ShipmentTrackingDTO>()
                .ForMember(dest => dest.AWB, src => src.MapFrom(x => x.Key))
                .ForMember(dest => dest.LastStatus, src => src.MapFrom(x => x.Value.FirstOrDefault().UpdateDescription));
           CreateMap<AramexShipmentLogs, ShipmentTrackingLogDto>()
                .ForMember(dest=>dest.StatusEnName,src=>src.MapFrom(x=>x.UpdateDescription))
                
                ;
            
            ///////////////////////////////////////////////////////////
            CreateMap<ShipmentDTO, MylerzShipment>()
                .ForPath(dest => dest.Street, src => src.MapFrom(x => x.CustomerAddress))
                .ForPath(dest => dest.Customer_Name, src => src.MapFrom(x => x.CustomerName))
                .ForPath(dest => dest.Mobile_No, src => src.MapFrom(x => x.CustomerPhoneNum))
                .ForPath(dest => dest.Package_Serial, src => src.MapFrom(x => new Random().Next(10000000)))
                .ForPath(dest => dest.Total_Weight, src => src.MapFrom(x => x.Weight))
                .ForPath(dest => dest.SpecialNotes, src => src.MapFrom(x => x.Note))
                .ForPath(dest => dest.Neighborhood, src => src.MapFrom(x => x.CustomerCity))
                .ForPath(dest => dest.COD_Value, src => src.MapFrom(x => x.TotalAmountShouldBeCollected))
                .ForPath(dest => dest.Payment_Type, src => src.MapFrom(x => x.TotalAmountShouldBeCollected > 0 ? "COD" : "PP"));
            CreateMap<MylerzPackage, ShipmentCreationResponseDTO>()
                .ForMember(dest => dest.AWB, src => src.MapFrom(x => x.BarCode));
            CreateMap<MylerzGetPDFResponse, GetPDFResponseDTO>()
                .ForMember(dest => dest.PDF, src => src.MapFrom(x => x.Value))
                .ForMember(dest => dest.Type, src => src.MapFrom(x => "Base64"));
            CreateMap<MylerzTrackShipmentValue, ShipmentTrackingDTO>()
                .ForMember(dest => dest.AWB, src => src.MapFrom(x => x.BarCode))
                .ForMember(dest => dest.LastStatus, src => src.MapFrom(x => x.Status));

            CreateMap<MylerzGetTrackingShipmentLogsResponse.TrackLog, ShipmentTrackingLogDto>()
                .ForMember(dest => dest.StatusEnName, src => src.MapFrom(x => x.StatusEnName))
                .ForMember(dest => dest.ChangedDate, src => src.MapFrom(x => x.ChangedDate))
                .ValidateMemberList(MemberList.None);

            ///////////////////////////////////////////////////////////
            CreateMap<ShipmentDTO, Shipment>()
                .ForMember(dest => dest.Provider, src => src.Ignore());
            CreateMap<Shipment, ShipmentDTO>();
            CreateMap<Provider, ProviderDTO>();
            CreateMap<City, CityDTO>();
            CreateMap<ProviderInformation, ProviderInformationDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, Product>();
            CreateMap<ShipmentProductDTO, ShipmentProduct>();
            CreateMap<ShipmentProduct, ShipmentProductDTO>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderProductDTO, OrderProduct>();
            CreateMap<OrderProduct, OrderProductDTO>();
            CreateMap<JTExpressCity, JTExpressCityDTO>().ForPath(des => des.JTExpressZoneId, src => src.MapFrom(src => src.JTExpressZoneId)).ReverseMap();
            CreateMap<JTExpressZone, JTExpressZoneDTO>().ReverseMap();  


            /////////////////////////////////// J&TExpress/////////////////////////////

            CreateMap<ShipmentDTO, JTExpressShipment>()
            .ForPath(des => des.Consignee.Name, src => src.MapFrom(con => con.CustomerName))
            .ForPath(des => des.Consignee.Phone, src => src.MapFrom(con => con.CustomerPhoneNum))
            .ForPath(des => des.Consignee.City, src => src.MapFrom(con => con.CustomerCity))
            .ForPath(des => des.Consignee.MailBox, src => src.MapFrom(con => con.CustomerEmail))
            .ForPath(des => des.Consignee.Mobile, src => src.MapFrom(con => con.CustomerPhoneNum))
            .ForPath(des => des.Consignee.Area,src => src.MapFrom(con => con.CustomerAddress))
               .ForPath(des => des.Shipper.Name, src => src.MapFrom(sh => sh.MerchantName))
            .ForPath(des => des.Shipper.Phone, src => src.MapFrom(sh => sh.MerchantPhoneNum))
            .ForPath(des => des.Shipper.City, src => src.MapFrom(sh => sh.MerchantCity))
            .ForPath(des => des.Shipper.MailBox, src => src.MapFrom(sh => sh.MerchantEmail))
            .ForPath(des => des.Shipper.Mobile, src => src.MapFrom(sh => sh.MerchantPhoneNum))
            .ForPath(des => des.Shipper.Area , src => src.MapFrom(sh => sh.MerchantAddress))
            .ForPath(des => des.Shipper.Company, src => src.MapFrom(sh => sh.MerchantCompanyName))
            .ForPath(des => des.TxlogisticId, src => src.MapFrom(sh => sh.AWB))
            .ForPath(des => des.ShipmentDetails.Weight, src => src.MapFrom(x => x.Weight))
            .ForPath(des => des.ShipmentDetails.TotalQuantity, src => src.MapFrom(x => x.NumberofPeices))
            .ForPath(des => des.ShipmentDetails.Remark, src => src.MapFrom(x => x.Note))
            .ForPath(des => des.ShipmentDetails.EXDRDescription, src => src.MapFrom(x => x.Description)).ReverseMap();

            CreateMap<JTExpressShipmentResponse, ShipmentCreationResponseDTO>()
              .ForMember(dest => dest.AWB, src => src.MapFrom(x => x.ID));

            CreateMap<JTExpressGetPDFResponse, GetPDFResponseDTO>()
              .ForMember(dest => dest.PDF, src => src.MapFrom(x => Convert.ToBase64String(x.ShipmentLabel.LabelFileContents)))
               .ForMember(dest => dest.Type, src => src.MapFrom(x => x.ShipmentLabel.billCode));



            CreateMap<JTExpressTrackShipment, ShipmentTrackingDTO>()
                .ForMember(dest => dest.AWB, src => src.MapFrom(x => x.Key))
                .ForMember(dest => dest.LastStatus, src => src.MapFrom(x => x.Value.FirstOrDefault().UpdateDescription));
            CreateMap<JTExpressShipmentLogs, ShipmentTrackingLogDto>()
                 .ForMember(dest => dest.StatusEnName, src => src.MapFrom(x => x.UpdateDescription));




        }
    }
}

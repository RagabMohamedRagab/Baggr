using Baggr.Providers.DTO.AramexModels;
using Baggr.Providers.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Gateway.IAPIs
{
    public interface IAramexAPI
    {
        public Task<AramexGetQuoteResponse> GetQuote(AramexGetQuoteBody aramexGetQuoteBody);
        public Task<AramexShipmentCreationResponse> CreateOrders(AramexShipmentsCreationBody aramexOrdersCreationBody);
        public Task<AramexPickupCreationResponse> CreatePickupOrders(AramexPickupCreationBody aramexPickupCreationBody);
        public Task<AramexGetPDFResponse> GetPDF(AramexGetPDFBody aramexGetPDFBody);
        Task<AramexTrackShipmentResponse> GetTrackingShipments(AramexTrackShipmentsBody aramexTrackShipmentsBody);
    }
}

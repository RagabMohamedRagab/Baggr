using Baggr.Providers.DTO.FedexModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Gateway.IAPIs
{
    public interface IFedexAPI
    {
        public Task<FedexGetQuoteResponse> GetQuote(FedexGetQuoteBody fedexGetQuoteBody);
        public Task<FedexShipmentCreationResponse> CreateOrder(FedexShipmentCreationBody fedexOrderBody);
        public Task<FedexGetPDFResponse> GetPDF(FedexGetPDFBody fedexGetPDFBody);
        public Task<FedexTrackShipmentResponse> TrackShipment(FedexTrackShipmentBody fedexTrackShipmentBody);
        public Task<FedexPickupCreationResponse> CreatePickup(FedexPickupCreationBody fedexPickupCreationBody);
    }
}

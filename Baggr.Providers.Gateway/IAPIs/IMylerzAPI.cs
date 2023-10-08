using Baggr.Providers.DTO.MylerzModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Gateway.IAPIs
{
    public interface IMylerzAPI
    {
        public Task<MylerzTokenResponse> GetToken(string url);
        public Task<MylerzCreateAddressResponse> CreateAddress(MylerzCreateAddressBody mylerzCreateAddressRequest, string token);
        public Task<MylerzCreateOrdersResponse> CreateOrders(IEnumerable<MylerzShipment> body, string token);
        public Task<MylerzGetQuoteResponse> GetQuote(MylerzGetQuoteBody mylerzGetQuoteBody, string token);
        public Task<MylerzCreatePickupResponse> CreatePickup(IEnumerable<MylerzPackage> body, string token);
        public Task<MylerzGetPDFResponse> GetPDF(MylerzGetPDFBody mylerzGetPDFBody, string token);
        public Task<MylerzTrackShipmentResponse> GetTrackingShipments(IEnumerable<string> body, string token);
        Task<MylerzGetTrackingShipmentLogsResponse> GetTrackingShipmentLogs(IEnumerable<MylerzGetTrackingShipmentLogsBody> body, string token);


    }
}

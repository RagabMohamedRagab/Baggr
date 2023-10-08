using Baggr.Providers.DTO.AramexModels;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.DTO.J_TExpressModels;
using Baggr.Providers.Gateway.APIs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Gateway.IAPIs {
    public  interface IJTExpressAPI{

        Task<JTExpressShipmentCreationResponse> CreateOrders(JTExpressShipmentsCreationBody jTExpressShipmentsCreationBody);
        Task<JTExpressTrackShipmentResponse> GetTrackingShipments(JTExpressTrackShipmentsBody JTExpressTrackShipmentsBody);
        Task<JTExpressGetPDFResponse> GetPDF(JTExpressGetPDFBody JTExpressGetPDFBody);
    }
}

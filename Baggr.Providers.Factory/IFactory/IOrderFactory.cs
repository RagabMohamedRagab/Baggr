using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Factory.IFactory
{
    public interface IOrderFactory
    {
        Task<ResultModel<string>> createOrders(OrderBulkDTO orderBulkDTO);
        ResultModel<OrdersPageDTO> GetOrders(string merchantKey, string searchTerm, int PageSize, int PageNumber, DateTime? from, DateTime? to, bool? isPayed);
        Task<ResultModel<OrderDTO>> GetOrderByKey(string orderKey);
        Task<ResultModel<string>> DeleteOrderByKey(string orderKey);
        Task MarkOrderPayed(string orderKey);
    }
}

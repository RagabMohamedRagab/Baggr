using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.DTO;
using Baggr.Providers.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.BLL.IManager
{
    public interface IOrderManager
    {
        Task<ResultModel<string>> CreateOrders(IList<Order> orders);
        ResultModel<OrdersPageDTO> GetOrders(string merchantKey, string searchTerm, int PageSize, int PageNumber, DateTime? from, DateTime? to, bool? isPayed);
        Task<ResultModel<Order>> GetOrderByKey(string orderKey);
        Task<ResultModel<string>> DeleteOrderByKey(string orderKey);
        Task<ResultModel<string>> DeleteOrderByKeys(IList<string> orderKeys);
        Task MarkOrderPayed(string orderKey);
    }
}

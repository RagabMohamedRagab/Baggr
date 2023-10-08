using AutoMapper;
using Baggr.Providers.BLL.IManager;
using Baggr.Providers.BLL.Manager;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.DTO;
using Baggr.Providers.Factory.IFactory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Baggr.Providers.Entities.Entities;

namespace Baggr.Providers.Factory.Factory
{
    public class OrderFactory : IOrderFactory
    {
        private readonly IOrderManager _orderManager;
        private readonly IMapper _mapper;
        public OrderFactory(IOrderManager orderManager, IMapper mapper)
        {
            _orderManager = orderManager;
            _mapper = mapper;
        }
        public async Task<ResultModel<string>> createOrders(OrderBulkDTO orderBulkDTO)
        {
            var orders = _mapper.Map<IEnumerable<OrderDTO>, IList<Order>>(orderBulkDTO.Orders);
            return await _orderManager.CreateOrders(orders);
        }
        public ResultModel<OrdersPageDTO> GetOrders(string merchantKey, string searchTerm, int PageSize, int PageNumber, DateTime? from, DateTime? to, bool? isPayed)
        {
            return _orderManager.GetOrders(merchantKey, searchTerm, PageSize, PageNumber, from, to, isPayed);
        }
        public async Task<ResultModel<OrderDTO>> GetOrderByKey(string orderKey)
        {
            var orderResult = await _orderManager.GetOrderByKey(orderKey);
            if (!orderResult.IsSuccess) return new ResultModel<OrderDTO>(false, StatusMessage.NotFound);
            return new ResultModel<OrderDTO>(true, StatusMessage.Ok, _mapper.Map<Order, OrderDTO>(orderResult.Result));
        }
        public async Task<ResultModel<string>> DeleteOrderByKey(string orderKey)
        {
            var orderResult = await _orderManager.DeleteOrderByKey(orderKey);
            if (!orderResult.IsSuccess) return new ResultModel<string>(false, StatusMessage.NotFound);
            return orderResult;
        }
        public async Task MarkOrderPayed(string orderKey)
        {
            await _orderManager.MarkOrderPayed(orderKey);
        }
    }
}

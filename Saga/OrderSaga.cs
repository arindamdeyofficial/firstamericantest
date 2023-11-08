using BusinessModel.Requests;
using Logging;
using Repository;
using System.Collections.Generic;

namespace Saga
{
    public class OrderSaga: IOrderSaga
    {
        private readonly IOrderRepository _ordrRepo;
        private readonly ILoggerHelper _logger;
        public OrderSaga(IOrderRepository ordrRepo, ILoggerHelper logger)
        {
            _ordrRepo = ordrRepo;
            _logger = logger;
        }

        public async Task<List<OrderModel>> Handle(CreateOrderRequest ord)
        {
            List < OrderModel > res = new List<OrderModel> ();
            try
            {
               res =  await _ordrRepo.GetOrders(ord);
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex);
            }
            return res;
        }
    }
}
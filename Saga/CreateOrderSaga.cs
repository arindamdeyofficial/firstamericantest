using AutoMapper;
using BusinessModel.Requests;
using Logging;
using Repository;
using Repository.Entity;

namespace Saga
{
    public class CreateOrderSaga : ICreateOrderSaga
    {
        private readonly IOrderRepository _ordrRepo;
        private readonly ILoggerHelper _logger;
        private readonly IMapper _mpr;
        public CreateOrderSaga(IOrderRepository ordrRepo, ILoggerHelper logger
            , IMapper mpr)
        {
            _ordrRepo = ordrRepo;
            _logger = logger;
            _mpr = mpr;
        }

        public async Task<bool> Handle(OrderModel ordr)
        {
           return await _ordrRepo.SubmitOrder(
               new OrderEntity
               {
                   Name = ordr.Name,
                   IsInvoiced = ordr.IsInvoiced,
                   IsDeleted = ordr.IsDeleted,
                   Id = ordr.Id,
                   EntryDate = ordr.EntryDate,
                   Desc = ordr.Desc
               });
        }
    }
}
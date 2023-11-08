using BusinessModel.Requests;

namespace Saga
{
    public interface IOrderSaga
    {
        Task<List<OrderModel>> Handle(CreateOrderRequest ord);
    }
}
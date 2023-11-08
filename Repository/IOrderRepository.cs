using BusinessModel.Requests;
using Repository.Entity;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<List<OrderModel>> GetOrders(CreateOrderRequest ord);
        Task<bool> SubmitOrder(OrderEntity ord);
    }
}
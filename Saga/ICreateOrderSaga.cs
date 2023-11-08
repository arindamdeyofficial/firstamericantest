using BusinessModel.Requests;

namespace Saga
{
    public interface ICreateOrderSaga
    {
        Task<bool> Handle(OrderModel ordr);
    }
}
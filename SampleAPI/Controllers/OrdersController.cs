using BusinessModel.Requests;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Saga;

namespace SampleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderSaga _ordrSaga;
        private readonly ICreateOrderSaga _crtOrdrSaga;
        // Add more dependencies as needed.

        public OrdersController(IOrderSaga ordrSaga, ICreateOrderSaga crtOrdrSaga)
        {
            _ordrSaga = ordrSaga;
            _crtOrdrSaga = crtOrdrSaga;
        }
 
        [HttpGet("Get")] // TODO: Change route, if needed.
        [ProducesResponseType(StatusCodes.Status200OK)] // TODO: Add all response types
        public async Task<ActionResult<List<OrderModel>>> Get(DateTime StartDate, DateTime EndDate, int OrderId)
        {
            var ordrObj = new CreateOrderRequest
            { StartDate = StartDate, EndDate = EndDate, OrderDetails = new OrderModel { Id = OrderId } };
            return new JsonResult(_ordrSaga.Handle(ordrObj));
        }

        [HttpPost("Post")] // TODO: Change route, if needed.
        [ProducesResponseType(StatusCodes.Status200OK)] // TODO: Add all response types
        public async Task<ActionResult<CreateOrderRequest>> Post(OrderModel ordr)
        {
            return new JsonResult(_crtOrdrSaga.Handle(ordr));
        }

        /// TODO: Add an endpoint to allow users to create an order using <see cref="CreateOrderRequest"/>.
    }
}

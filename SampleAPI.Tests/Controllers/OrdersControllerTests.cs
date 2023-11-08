using BusinessModel.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Saga;
using SampleAPI.Controllers;
using System.Linq;

namespace SampleAPI.Controllers.Tests
{
    [TestClass()]
    public class OrdersControllerTests
    {
        private readonly Mock<IOrderSaga> _ordrSaga;
        private readonly Mock<ICreateOrderSaga> _crtOrdrSaga;
        private readonly OrdersController _rdersController;
        public OrdersControllerTests()
        {            
            _ordrSaga = new Mock<IOrderSaga>();
            _ordrSaga.Setup(a => a.Handle(It.IsAny<CreateOrderRequest>()))
                .Returns(Task.FromResult(new List<OrderModel>()));

            _crtOrdrSaga = new Mock<ICreateOrderSaga>();
            _crtOrdrSaga.Setup(a => a.Handle(It.IsAny<OrderModel>()))
                .Returns(Task.FromResult(true));

            _rdersController = new OrdersController(_ordrSaga.Object, _crtOrdrSaga.Object);
        }
        [TestMethod()]
        public async void GetTest()
        {
            var res = await _rdersController.Get(DateTime.Today, DateTime.Today, 1);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(res);
        }

        [TestMethod()]
        public async void PostTest()
        {
            var res = await _rdersController.Post(new OrderModel());
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(res);
        }
    }
}

namespace BusinessModel.Requests
{
    public class CreateOrderRequest
    {
        public OrderModel OrderDetails { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsRecent { get; set; }
    }
}
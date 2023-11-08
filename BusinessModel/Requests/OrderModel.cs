namespace BusinessModel.Requests
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public bool IsInvoiced { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
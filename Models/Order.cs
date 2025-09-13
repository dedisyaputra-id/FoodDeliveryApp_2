namespace webapifirst.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public float? TotalAmount { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public string? OpAdd { get; set; }
        public string? PcAdd { get; set; }
        public DateTime? DateAdd { get; set; }
        public string? OpEdit { get; set; }
        public string? PcEdit { get; set; }
        public string? DateEdit { get; set; }
        public byte dlt { get; set; }
    }
}

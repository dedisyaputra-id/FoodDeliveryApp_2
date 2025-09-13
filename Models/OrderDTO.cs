namespace webapifirst.Models
{
    public class OrderDTO
    {
        public string? OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public float? TotalAmount { get; set; }
        public ICollection<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();
    }
}

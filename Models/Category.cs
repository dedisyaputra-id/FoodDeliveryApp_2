namespace webapifirst.Models
{
    public class Category
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string? OpAdd { get; set; }
        public string? PcAdd { get; set; }
        public DateTime? DateAdd { get; set; }
        public string? OpEdit { get; set; }
        public string? PcEdit { get; set; }
        public string? DateEdit { get; set; }
        public byte dlt {  get; set; }
        public ICollection<Product> Product { get; set; }
    }
}

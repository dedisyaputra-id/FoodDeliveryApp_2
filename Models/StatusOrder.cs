using System.ComponentModel;

namespace webapifirst.Models
{
    public enum StatusOrder
    {
        Pending = 0,
        Paid = 1,
        Processing = 2,
        Shipped = 3,
        Delivered = 4,
        Cancelled = 5,
        Returned = 6,
    }
}

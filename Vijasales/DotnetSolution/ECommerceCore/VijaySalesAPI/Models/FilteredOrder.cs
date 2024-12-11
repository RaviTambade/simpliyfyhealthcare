
using OrderProcessing.Entities;

namespace VijaySalesAPI.Models
{
    public class FilteredOrder
    {
        public OrderList order { get; set; }
        public string status { get; set; }

    }
}

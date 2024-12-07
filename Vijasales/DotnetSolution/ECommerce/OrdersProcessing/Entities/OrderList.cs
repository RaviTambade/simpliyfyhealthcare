using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersProcessing.Entities
{
    public class OrderList
    {
        public int OrderId { get; set; }          // o.Id AS OrderId
        public string Name { get; set; }          // (u.FirstName + ' ' + u.LastName) AS Name
        public string Brand { get; set; }         // p.Brand AS Brand
        public string Title { get; set; }         // p.Title AS Title
        public int Quantity { get; set; }         // t.Quantity AS Quantity
        public decimal Price { get; set; }        // p.Price AS Price
        public decimal TotalPrice { get; set; }   // (t.Quantity * p.Price) AS TotalPrice
        public DateTime OrderDate { get; set; }   // o.OrderDate AS OrderDate
        public string OrderStatus { get; set; }   // o.Status AS OrderStatus
    }
}

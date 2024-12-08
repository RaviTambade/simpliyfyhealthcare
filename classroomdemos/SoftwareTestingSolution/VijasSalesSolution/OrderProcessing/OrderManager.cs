using OrderProcessing.Entities;

namespace OrderProcessing.Repositories
{
    public class OrderManager
    {
        public static List<Order> GetAll()
        {
            var orders = new List<Order>();
            orders.Add(new Order { Id = 234, Owner = "Rajiv", TotalAmount = 8900 });
            orders.Add(new Order { Id = 235, Owner = "Sameer", TotalAmount = 5600 });
            orders.Add(new Order { Id = 236, Owner = "Manoj", TotalAmount = 900 });
            orders.Add(new Order { Id = 237, Owner = "Mangesh", TotalAmount = 670 });
            orders.Add(new Order { Id = 238, Owner = "Sitaram", TotalAmount = 1250 });
            return orders;
        }

        public static Order GetById(int id)
        {
            Order order = new Order { Id = 238, Owner = "Sitaram", TotalAmount = 1250 };
            return order;
        }

        public static bool Insert(Order Order)
        {
            List<Order> orders = GetAll();
            orders.Add(Order);
            return true;

        }

        public static bool Update(Order Order)
        {
            List<Order> orders = GetAll();
            //Orders.Add(Order);
            //logic to update exsting Order from collection
            return true;

        }
        public static bool Delete(Order Order)
        {
            List<Order> orders = GetAll();
            //logic to remove Order from collection
            return true;

        }
    }
}


using OrdersProcessing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
namespace OrdersProcessing.Repositories.ORM
{

    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public OrderContext() : base("name=conString") { }
    }
    public class OrderRepository : IOrderRepository
    {
        public bool Delete(int id)
        {
            bool status = false;
            using (var ctx = new OrderContext())
            {
                var dbProducts = ctx.Orders.ToList();
                foreach (var dbProduct in dbProducts)
                {
                    if(dbProduct.Id == id)
                    {
                        ctx.Orders.Remove(dbProduct);
                        status = true;
                    }
                }
            }
            return status;
        }

        public List<Order> GetAll()
        {
            List<Order> orders = new List<Order>();
            using(var ctx = new OrderContext())
            {
                var dbProducts = ctx.Orders.ToList();
                foreach(var dbProduct in dbProducts)
                {
                    Order order = new Order();
                    order.Id=dbProduct.Id;
                    order.OrderDate = dbProduct.OrderDate;
                    order.CustomerId = dbProduct.CustomerId;
                    order.Status = dbProduct.Status;
                    order.TotalAmount = dbProduct.TotalAmount;
                    orders.Add(order);
                }
            }
            return orders;
        }

        public List<Order> GetCustomerOrder(int customerId)
        {
            List<Order> orders = new List<Order>();
            using (var ctx = new OrderContext())
            {
                var dbProducts = ctx.Orders.ToList();
                foreach (var dbProduct in dbProducts)
                {
                    if (dbProduct.CustomerId == customerId)
                    {
                        Order order = new Order();
                        order.Id = dbProduct.Id;
                        order.OrderDate = dbProduct.OrderDate;
                        order.CustomerId = dbProduct.CustomerId;
                        order.Status = dbProduct.Status;
                        order.TotalAmount = dbProduct.TotalAmount;
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }

        public Order GetOrder(int id)
        {
            Order order = new Order();
            using (var ctx = new OrderContext())
            {
                var dbProducts = ctx.Orders.ToList();
                foreach (var dbProduct in dbProducts)
                {
                    if (dbProduct.Id == id)
                    {
                        
                        order.Id = dbProduct.Id;
                        order.OrderDate = dbProduct.OrderDate;
                        order.CustomerId = dbProduct.CustomerId;
                        order.Status = dbProduct.Status;
                        order.TotalAmount = dbProduct.TotalAmount;
                        
                    }
                }
            }
            return order;
        }

        public bool Insert(Order order)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order order)
        {
            bool status = false;
            using(var ctx = new OrderContext())
            {
                var dbProducts = ctx.Orders.ToList();
                foreach (var dbProduct in dbProducts) { 
                    if(dbProduct.Id == order.Id)
                    {
                        dbProduct.OrderDate = order.OrderDate;
                        dbProduct.CustomerId = order.CustomerId;
                        dbProduct.Status = order.Status;
                        dbProduct.TotalAmount = order.TotalAmount;
                        ctx.SaveChanges();
                        status = true;
                    }
                }
            }
            return status;
        }
    }
}

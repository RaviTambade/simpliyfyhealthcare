using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using OrdersProcessing.Entities;
using OrdersProcessing.Repositories;
using System.Data;

namespace OrdersProcessing.Repositories.Connected
{
    public class OrderRepository : IOrderRepository 
    {
        string conString = string.Empty;

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrder(int customerId)
        {
            List<Order> orders = new List<Order>();
            IDbConnection conn = new SqlConnection(conString);
            string query = "SELECT * FROM VSORDERS WHERE CUSTOMERID=" + customerId;
            IDbCommand cmd = new SqlCommand(query, conn as SqlConnection);
            try
            {
                conn.Open();
                IDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    Order order = new Order();
                    order.Id = Convert.ToInt32(data["Id"].ToString());
                    order.CustomerId = Convert.ToInt32(data["CustomerId"].ToString());
                    order.Status = data["Status"].ToString();
                    order.OrderDate = DateTime.Parse(data["OrderDate"].ToString());
                    order.TotalAmount = Convert.ToDecimal(data["TotalAmount"].ToString());
                    orders.Add(order);
                }
            }
            catch (Exception ex)
            {
                //Catch exception
            }
            finally
            {
                conn.Close();
            }
            return orders;
        }


        public List<Order> GetAll()
        {
            IDbConnection conn = new SqlConnection(conString);
            string query = "SELECT * FROM VsOrders";
            IDbCommand cmd = new SqlCommand(query, conn as SqlConnection);
            List<Order> orders = new List<Order>();
            try
            {
                conn.Open();
                IDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    Order order = new Order();
                    order.Id = Convert.ToInt32(data["Id"].ToString());
                    order.CustomerId = Convert.ToInt32(data["CustomerId"].ToString());
                    order.Status = data["Status"].ToString();
                    order.OrderDate = DateTime.Parse(data["OrderDate"].ToString());
                    order.TotalAmount = Convert.ToDecimal(data["TotalAmount"].ToString());
                    orders.Add(order);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return orders;
        }


        public Order GetOrder(int id)
        {
            Order order = new Order();
            IDbConnection conn = new SqlConnection(conString);
            string query = "SELECT * FROM VsOrders WHERE ID=" + id;
            IDbCommand cmd = new SqlCommand(query, conn as SqlConnection);

            try
            {
                conn.Open();
                IDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {

                    order.Id = Convert.ToInt32(data["Id"].ToString());
                    order.CustomerId = Convert.ToInt32(data["CustomerId"].ToString());
                    order.Status = data["Status"].ToString();
                    order.OrderDate = DateTime.Parse(data["OrderDate"].ToString());
                    order.TotalAmount = Convert.ToDecimal(data["TotalAmount"].ToString());

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return order;
        }

        public bool Insert(Order order)
        {
            bool status = false;
            IDbConnection conn = new SqlConnection(conString);
            string query = string.Format("INSERT INTO VSORDERS (CUSTOMERID,STATUS,TOTALAMOUNT,ORDERDATE) VALUES({0},'{1}',{2},'{3}')", order.CustomerId, order.Status, order.TotalAmount, order.OrderDate);
            IDbCommand cmd = new SqlCommand(query, conn as SqlConnection);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        public bool Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}

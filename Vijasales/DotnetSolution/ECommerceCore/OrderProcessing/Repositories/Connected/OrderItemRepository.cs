using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OrderProcessing.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Repositories.Connected
{
    public class OrderItemRepository:IOrderItemRepository
    {
        public string conString;

        private IConfiguration _configuration;
        public OrderItemRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            conString = this._configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<bool> InsertOrderItemAsync(OrderItem item)
        {
            bool status = false;
            SqlConnection conn = new SqlConnection(conString);
            string query = "INSERT INTO VSORDERITEMS(ORDERID,PRODUCTID,QUANTITY) VALUES (@OrderId,@ProductId,@Quantity)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@OrderId", item.OrderId);
            cmd.Parameters.AddWithValue("@ProductId", item.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
            try
            {
                await conn.OpenAsync();
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await conn.CloseAsync();
            }
            return status;
        }

        public async Task<bool> UpdateOrderItemAsync(int customerId, OrderItem item)
        {
            bool status = false;
            SqlConnection conn = new SqlConnection(conString);
            string query = "UPDATE VSORDERITEMS SET PRODUCTID=@Productid, QUANTITY=@Quantity";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Productid", item.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
            try
            {
                await conn.OpenAsync();
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await conn.CloseAsync();
            }
            return status;
        }

        public async Task<bool> DeleteOrderItemAsync(int orderId)
        {
            SqlConnection conn = new SqlConnection(conString);
            string query = "DELETE VSORDERITEMS WHERE ORDERID=@orderId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@orderId", orderId);
            bool status = false;
            try
            {
                await conn.OpenAsync();
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await conn.CloseAsync();
            }
            return status;
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
        {
            SqlConnection conn = new SqlConnection(conString);
            string query = "SELECT * FROM VSORDERITEMS WHERE ID=@orderItemid";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@orderItemid", orderItemId);
            OrderItem orderItem = new OrderItem();
            try
            {
                await conn.OpenAsync();
                IDataReader reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                {
                    orderItem.OrderId = Convert.ToInt32(reader["OrderId"].ToString());
                    orderItem.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                    orderItem.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
                    orderItem.Id = Convert.ToInt32(reader["Id"].ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await conn.CloseAsync();
            }
            return orderItem;
        }

        public async Task<List<OrderItem>> GetAllOrderItemsAsync(int orderId)
        {
            SqlConnection conn = new SqlConnection(conString);
            string query = "SELECT * FROM VSORDERITEMS WHERE OrderId=@Orderid";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Orderid", orderId);
            List<OrderItem> orderItems = new List<OrderItem>();
            try
            {
                await conn.OpenAsync();
                IDataReader reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                {
                    OrderItem orderItem = new OrderItem();
                    orderItem.OrderId = Convert.ToInt32(reader["OrderId"].ToString());
                    orderItem.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                    orderItem.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
                    orderItem.Id = Convert.ToInt32(reader["Id"].ToString());
                    orderItems.Add(orderItem);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await conn.CloseAsync();
            }
            return orderItems;
        }

        public async Task<List<OrderItem>> GetAllOrderItemsByCustomerIdAsync(int customerId)
        {
            SqlConnection conn = new SqlConnection(conString);
            string query = "SELECT * FROM VSORDERITEMS WHERE CustomerId=@CustomerId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CustomerId", customerId);
            List<OrderItem> orderItems = new List<OrderItem>();
            try
            {
                await conn.OpenAsync();
                IDataReader reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                {
                    OrderItem orderItem = new OrderItem();
                    orderItem.OrderId = Convert.ToInt32(reader["OrderId"].ToString());
                    orderItem.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                    orderItem.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
                    orderItem.Id = Convert.ToInt32(reader["Id"].ToString());
                    orderItems.Add(orderItem);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await conn.CloseAsync();
            }
            return orderItems;
        }
    }
}

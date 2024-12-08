using Microsoft.Data.SqlClient;
using OrderProcessing.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OrderProcessing.Responses;

namespace OrderProcessing.Repositories.Connected
{
    public class OrderRepository : IOrderRepository
    {
        public string conString;

        private IConfiguration _configuration;
        public OrderRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            conString = this._configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool status = false;
            SqlConnection conn = new SqlConnection(conString);
            string query = "DELETE VSORDERS WHERE ID=@Id";
            SqlCommand cmd = new SqlCommand(query,conn);
            SqlParameter IdParameter = new SqlParameter("@Id",SqlDbType.Int);
            IdParameter.Value = id;
            cmd.Parameters.Add(IdParameter);
            try
            {
                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                await conn.CloseAsync();
            }
            return status;
        }

        public async Task<List<Order>> GetCustomerOrderAsync(int customerId)
        {
            List<Order> orders = new List<Order>();
            SqlConnection conn = new SqlConnection(conString);
            string query = "SELECT * FROM VSORDERS WHERE CUSTOMERID=@CustomerId";
            SqlCommand cmd = new SqlCommand(query, conn);
            //Set Parameter for insert Query
            SqlParameter CustomeridParameter = new SqlParameter("@CustomerId", SqlDbType.Int);
            CustomeridParameter.Value = customerId;
            cmd.Parameters.Add(CustomeridParameter);
            try
            {
                await conn.OpenAsync();
                IDataReader data = await cmd.ExecuteReaderAsync();
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
                await conn.CloseAsync();
            }
            return orders;
        }


        public async Task<List<Order>> GetAllAsync()
        {
            SqlConnection conn = new SqlConnection(conString);
            string query = "SELECT * FROM VsOrders";
            SqlCommand cmd = new SqlCommand(query, conn);
            List<Order> orders = new List<Order>();
            try
            {
                await conn.OpenAsync();
                IDataReader data = await cmd.ExecuteReaderAsync();
                while(data.Read())
                {
                    Order order = new Order();
                    order.Id = Convert.ToInt32(data["Id"].ToString());
                    order.CustomerId = Convert.ToInt32(data["CustomerId"].ToString());
                    order.Status = data["Status"].ToString();
                    order.OrderDate = DateTime.Parse(data["OrderDate"].ToString());
                    order.TotalAmount = Convert.ToDecimal(data["TotalAmount"].ToString());
                    orders.Add(order);
                }
                
            }catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            finally
            {
                await conn.CloseAsync();
            }
            return orders;
        }


        public async Task<Order> GetOrderAsync(int id)
        {
            Order order = new Order();
            SqlConnection conn = new SqlConnection(conString);
            string query = "SELECT * FROM VsOrders WHERE ID=@Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter IdParameter = new SqlParameter("@Id", SqlDbType.Int);
            IdParameter.Value = id;
            cmd.Parameters.Add(IdParameter);
            
            try
            {
                await conn.OpenAsync();
                IDataReader data = await cmd.ExecuteReaderAsync();
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
                await conn.CloseAsync();
            }
            return order;
        }

        public async Task<bool> InsertAsync(Order order)
        {
            bool status = false;
            SqlConnection conn = new SqlConnection(conString);
            string query = "INSERT INTO VSORDERS(CUSTOMERID, STATUS, TOTALAMOUNT, ORDERDATE) VALUES(@CustomerId,@Status,@TotalAmount,@OrderDate)";
            SqlCommand cmd = new SqlCommand(query, conn as SqlConnection);
            
            //Set Parameter for insert Query
            SqlParameter CustomeridParameter = new SqlParameter("@CustomerId", SqlDbType.Int);
            CustomeridParameter.Value = order.CustomerId;
            SqlParameter TotalAmountParameter = new SqlParameter("@TotalAmount", SqlDbType.Decimal);
            TotalAmountParameter.Value = order.TotalAmount;
            SqlParameter OrderDateParameter = new SqlParameter("@OrderDate", SqlDbType.DateTime);
            OrderDateParameter.Value = order.OrderDate;
            SqlParameter StatusParameter = new SqlParameter("@Status", SqlDbType.VarChar);
            StatusParameter.Value = order.Status;

            //Add Parameter to Query/Command
            cmd.Parameters.Add(CustomeridParameter);
            cmd.Parameters.Add(TotalAmountParameter);
            cmd.Parameters.Add(OrderDateParameter);
            cmd.Parameters.Add(StatusParameter);
            try
            {
                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
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

        public async Task<bool> UpdateAsync(Order order)
        {
            bool status = false;
            SqlConnection conn = new SqlConnection(conString);
            string query = "UPDATE VSORDERS SET CUSTOMERID=@CustomerId , STATUS=@Status , TOTALAMOUNT=@TotalAmount , ORDERDATE=@OrderDate  WHERE ID=@Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            //Set Paramter for Update Query
            SqlParameter IdParameter = new SqlParameter("@Id",SqlDbType.Int);
            IdParameter.Value = order.Id;
            SqlParameter CustomeridParameter = new SqlParameter("@CustomerId",SqlDbType.Int);
            CustomeridParameter.Value = order.CustomerId;
            SqlParameter TotalAmountParameter = new SqlParameter("@TotalAmount",SqlDbType.Decimal);
            TotalAmountParameter.Value = order.TotalAmount;
            SqlParameter OrderDateParameter = new SqlParameter("OrderDate",SqlDbType.DateTime);
            OrderDateParameter.Value = order.OrderDate;
            SqlParameter StatusParameter = new SqlParameter("@Status",SqlDbType.VarChar);
            StatusParameter.Value = order.Status;

            //Add Parameter to Query/Command
            cmd.Parameters.Add(IdParameter);
            cmd.Parameters.Add(CustomeridParameter);
            cmd.Parameters.Add(TotalAmountParameter);
            cmd.Parameters.Add(OrderDateParameter);
            cmd.Parameters.Add(StatusParameter);

            try
            {
                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                await conn.CloseAsync();
            }

            return status;
        }
        public async Task<List<OrderList>> GetOrderDetailsAsync(int customerId)
        {
            OrderResponse response = new OrderResponse();
            SqlConnection conn = new SqlConnection(conString);
            string query = "EXEC VsGetCurrentOrderDetails @CustomerId";
            SqlCommand cmd = new SqlCommand(query,conn as SqlConnection);
            SqlParameter customerIdParameter = new SqlParameter("@CustomerId",SqlDbType.Int);
            customerIdParameter.Value = customerId;
            cmd.Parameters.Add(query);
            try
            {
                await conn.OpenAsync();
                IDataReader dr = await cmd.ExecuteReaderAsync();
                while(dr.Read())
                {
                    int orderId = Convert.ToInt32(dr["OrderId"].ToString());
                    string name = dr["Name"].ToString();
                    string brand = dr["Brand"].ToString();
                    string title = dr["Title"].ToString();
                    int quantity = Convert.ToInt32(dr["Quantity"].ToString());
                    decimal price = Convert.ToDecimal(dr["Price"].ToString());
                    decimal totalPrice = Convert.ToDecimal(dr["TotalPrice"].ToString());
                    DateTime orderdate = Convert.ToDateTime(dr["OrderDate"].ToString());
                    string orderStatus = dr["OrderStatus"].ToString();

                    OrderList orderList = new OrderList {
                        OrderId = orderId,
                        Name = name,
                        Brand = brand,
                        Title = title,
                        Quantity = quantity,
                        Price = price,
                        TotalPrice = totalPrice,
                        OrderDate = orderdate,
                        OrderStatus = orderStatus,
                    };
                    response.OrderLists.Add(orderList);
                }
            }catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                await conn.CloseAsync();
            }
            
            return response.OrderLists;
        }
    }
}

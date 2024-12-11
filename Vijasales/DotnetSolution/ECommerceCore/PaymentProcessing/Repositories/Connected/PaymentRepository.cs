using PaymentProcessing.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderProcessing.Entities;

namespace PaymentProcessing.Repositories.Connected
{
    public class PaymentRepository:IPaymentRepository
    {
        public string _conString;
        private IConfiguration _configuration;

        public PaymentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _conString = _configuration.GetConnectionString("DefaultConnection");
        }
        //
        public async Task<List<Payment>> GetAllAsync()
        {
            SqlConnection conn = new SqlConnection(_conString);
            string query = "SELECT * FROM VsPayments";
            SqlCommand cmd = new SqlCommand(query, conn);
            List<Payment> payments = new List<Payment>();
            try
            {
                await conn.OpenAsync();
                IDataReader data = await cmd.ExecuteReaderAsync();
                while (data.Read())
                {
                    Payment payment = new Payment();
                    payment.Id = Convert.ToInt32(data["Id"].ToString());
                    payment.OrderId = Convert.ToInt32(data["OrderId"].ToString());
                    payment.PaymentDate = data["PaymentDate"].ToString();
                    payment.PaymentAmount = Convert.ToDouble(data["PaymentAmount"].ToString());
                    payment.PaymentMode = data["PaymentMode"].ToString();
                    payment.PaymentStatus = data["PaymentStatus"].ToString();
                    payment.TransactionId = data["TransactionId"].ToString();
                    payments.Add(payment);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            finally
            {
                await conn.CloseAsync();
            }
            return payments;
        }

        public async Task<Payment> GetPaymentAsync(int id)
        {
            Payment payment = new Payment();
            SqlConnection conn = new SqlConnection(_conString);
            string query = "SELECT * FROM VsPayments WHERE OrderId=@OrderId";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter OrderIdParameter = new SqlParameter("@OrderId", SqlDbType.Int);
            OrderIdParameter.Value = id;
            cmd.Parameters.Add(OrderIdParameter);

            try
            {
                await conn.OpenAsync();
                IDataReader data = await cmd.ExecuteReaderAsync();
                if (data.Read())
                {

                    payment.Id = Convert.ToInt32(data["Id"].ToString());
                    payment.OrderId = Convert.ToInt32(data["OrderId"].ToString());
                    payment.PaymentDate = data["PaymentDate"].ToString();
                    payment.PaymentAmount = Convert.ToDouble(data["PaymentAmount"].ToString());
                    payment.PaymentMode = data["PaymentMode"].ToString();
                    payment.PaymentStatus = data["PaymentStatus"].ToString();
                    payment.TransactionId = data["TransactionId"].ToString();
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
            return payment;
        }

        public async Task<double> GetTotalRevenueForAccountAsync(int month, string accountNumber)
        {
            SqlConnection conn = new SqlConnection(_conString);

            // Query to sum up the payment amounts for the specified account number in the given month
            string query = @"SELECT SUM(p.PaymentAmount) AS TotalRevenue
                            FROM VsPayments p
                            JOIN VsOrders o ON p.OrderId = o.Id
                            JOIN VsAccounts a ON o.CustomerId = a.UserId
                            WHERE a.AccountNumber = @AccountNumber
                            AND MONTH(p.PaymentDate) = @Month
                            GROUP BY a.AccountNumber";

            SqlCommand cmd = new SqlCommand(query, conn);

            // Add parameters to avoid SQL injection
            cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);
            cmd.Parameters.AddWithValue("@Month", month);

            double totalRevenue = 0;

            try
            {
                await conn.OpenAsync();
                var result = await cmd.ExecuteScalarAsync();

                if (result != DBNull.Value)
                {
                    totalRevenue = Convert.ToDouble(result);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            finally
            {
                await conn.CloseAsync();
            }

            return totalRevenue;
        }

        // Fetch payments for a specific customer by their CustomerId
        public async Task<List<Payment>> GetPaymentsByCustomerIdAsync(int customerId)
        {
            SqlConnection conn = new SqlConnection(_conString);

            // Use a JOIN query to fetch payments associated with the customer's orders
            string query = @"
                SELECT p.*
                FROM VsPayments p
                JOIN VsOrders o ON p.OrderId = o.Id
                WHERE o.CustomerId = @CustomerId";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter customerIdParameter = new SqlParameter("@CustomerId", SqlDbType.Int);
            customerIdParameter.Value = customerId;
            cmd.Parameters.Add(customerIdParameter);

            List<Payment> payments = new List<Payment>();

            try
            {
                await conn.OpenAsync();
                IDataReader data = await cmd.ExecuteReaderAsync();
                while (data.Read())
                {
                    Payment payment = new Payment
                    {
                        Id = Convert.ToInt32(data["Id"].ToString()),
                        OrderId = Convert.ToInt32(data["OrderId"].ToString()),
                        PaymentDate = data["PaymentDate"].ToString(),
                        PaymentAmount = Convert.ToDouble(data["PaymentAmount"].ToString()),
                        PaymentMode = data["PaymentMode"].ToString(),
                        PaymentStatus = data["PaymentStatus"].ToString(),
                        TransactionId = data["TransactionId"].ToString()
                    };
                    payments.Add(payment);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            finally
            {
                await conn.CloseAsync();
            }

            return payments;
        }

        public async Task<int> InsertAsync(Payment payment)
        {
            int insertedId = 0;
            SqlConnection conn = new SqlConnection(_conString);
            
            string query = @"INSERT INTO VsPayments (OrderId, PaymentDate, PaymentAmount, PaymentMode, PaymentStatus)
        
                            VALUES (@OrderId, @PaymentDate, @PaymentAmount, @PaymentMode, @PaymentStatus);

                            SELECT SCOPE_IDENTITY();"; // This retrieves the last inserted identity value SqlCommand cmd = new SqlCommand(query, conn as SqlConnection);

            SqlCommand cmd = new SqlCommand(query, conn);
            //Set Parameter for insert Query
            SqlParameter OrderIdParameter = new SqlParameter("@OrderId", SqlDbType.Decimal);
            OrderIdParameter.Value = payment.OrderId;
            DateTime currentDate = DateTime.Now.Date;
            string formattedDate = currentDate.ToString("yyyy-MM-dd");
            SqlParameter PaymentDateParameter = new SqlParameter("PaymentDate", SqlDbType.DateTime);

            PaymentDateParameter.Value = formattedDate;
            SqlParameter PaymentAmountParameter = new SqlParameter("@PaymentAmount", SqlDbType.VarChar);
            PaymentAmountParameter.Value = payment.PaymentAmount;

            SqlParameter PaymentModeParameter = new SqlParameter("@PaymentMode", SqlDbType.VarChar);
            PaymentModeParameter.Value = payment.PaymentMode;
            SqlParameter PaymentStatusParameter = new SqlParameter("@PaymentStatus", SqlDbType.VarChar);
            PaymentStatusParameter.Value = "Pending";
            //Add Parameter to Query/Command
            cmd.Parameters.Add(OrderIdParameter);
            cmd.Parameters.Add(PaymentDateParameter);
            cmd.Parameters.Add(PaymentAmountParameter);
            cmd.Parameters.Add(PaymentModeParameter);
            cmd.Parameters.Add(PaymentStatusParameter);
            try
            {
                await conn.OpenAsync();
                insertedId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                return insertedId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await conn.CloseAsync();
            }
            return insertedId;
        }

        public async Task<bool> UpdateAsync(Payment payment)
        {
            bool status = false;
            SqlConnection conn = new SqlConnection(_conString);
            string query = "UPDATE VsPayments SET  OrderId=@OrderId , PaymentAmount=@PaymentAmount, PaymentMode=@PaymentMode,PaymentStatus=@PaymentStatus, TransactionId = @TransactionId, PaymentDate=@PaymentDate   WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            //Set Paramter for Update Query
            SqlParameter IdParameter = new SqlParameter("@Id", SqlDbType.Int);
            IdParameter.Value = payment.Id;
            SqlParameter OrderIdParameter = new SqlParameter("@OrderId", SqlDbType.Decimal);
            OrderIdParameter.Value = payment.OrderId;
            SqlParameter PaymentDateParameter = new SqlParameter("@PaymentDate", SqlDbType.DateTime);
            PaymentDateParameter.Value = payment.PaymentDate;
            SqlParameter PaymentAmountParameter = new SqlParameter("@PaymentAmount", SqlDbType.Decimal);
            PaymentAmountParameter.Value = payment.PaymentAmount;

            SqlParameter PaymentModeParameter = new SqlParameter("@PaymentMode", SqlDbType.VarChar);
            PaymentModeParameter.Value = payment.PaymentMode; 
            SqlParameter PaymentStatusParameter = new SqlParameter("@PaymentStatus", SqlDbType.VarChar);
            PaymentStatusParameter.Value = payment.PaymentStatus;
            SqlParameter TransactionIdParameter = new SqlParameter("@TransactionId", SqlDbType.VarChar);
            TransactionIdParameter.Value = payment.TransactionId;

            //Add Parameter to Query/Command
            cmd.Parameters.Add(IdParameter);
            cmd.Parameters.Add(OrderIdParameter);
            cmd.Parameters.Add(PaymentDateParameter);
            cmd.Parameters.Add(PaymentAmountParameter);
            cmd.Parameters.Add(PaymentModeParameter);
            cmd.Parameters.Add(PaymentStatusParameter);
            cmd.Parameters.Add(TransactionIdParameter);
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

        public async Task<double> GetAmount(int OrderId)

        {

            double amount = -1;

            using (SqlConnection conn = new SqlConnection(_conString))

            {

                string query = "SELECT TotalAmount FROM VsOrders WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlParameter IdParameter = new SqlParameter("@Id", SqlDbType.Int);

                IdParameter.Value = OrderId;

                cmd.Parameters.Add(IdParameter);

                try

                {

                    await conn.OpenAsync();

                    using (SqlDataReader data = await cmd.ExecuteReaderAsync()) // Use SqlDataReader

                    {

                        // Check if there's at least one record returned

                        if (await data.ReadAsync()) // Read the first row (if exists)

                        {

                            // Get the value of 'TotalAmount' column and convert it to int

                            amount = (double)data.GetDecimal(data.GetOrdinal("TotalAmount"));

                        }

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

            }

            return amount;

        }

        public async Task<(string status, string Tid)> ExecuteFundTransferProcedure(string customerAccountId, string adminAccountId, double amount, string paymentMode)

        {

            string status = "Failed";  // Default status if an error occurs

            string Tid = string.Empty;  // Initialize Tid to store the transaction ID

            using (var connection = new SqlConnection(_conString))

            {

                await connection.OpenAsync();

                using (var command = new SqlCommand("VsFundTransfer", connection))

                {

                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure

                    command.Parameters.Add(new SqlParameter("@ToAccountNumber", SqlDbType.VarChar, 20) { Value = adminAccountId.ToString() });

                    command.Parameters.Add(new SqlParameter("@FromAccountNumber", SqlDbType.VarChar, 20) { Value = customerAccountId.ToString() });

                    command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal) { Value = amount });

                    command.Parameters.Add(new SqlParameter("@PaymentMode", SqlDbType.VarChar, 50) { Value = paymentMode });

                    // Output parameters for TransactionId and Status

                    var transactionIdParam = new SqlParameter("@TransactionId", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };

                    var statusParam = new SqlParameter("@Status", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };

                    command.Parameters.Add(transactionIdParam);

                    command.Parameters.Add(statusParam);

                    try

                    {

                        // Execute the stored procedure

                        await command.ExecuteNonQueryAsync();

                        // Retrieve the TransactionId and Status from the output parameters

                        Tid = transactionIdParam.Value.ToString();

                        status = statusParam.Value.ToString();

                        // If the status is 'Success', we set it to 'Complete'

                        if (status == "Success")

                        {

                            status = "Complete";

                        }

                        else

                        {

                            status = "Failed";

                        }

                    }

                    catch (SqlException sqlEx)

                    {

                        // Handle SQL exceptions

                        status = $"SQL Error: {sqlEx.Message}";

                    }

                    catch (Exception ex)

                    {

                        // Handle general exceptions

                        status = $"Error: {ex.Message}";

                    }

                    finally

                    {

                        await connection.CloseAsync();

                    }

                }

            }

            return (status, Tid);

        }


    }
}

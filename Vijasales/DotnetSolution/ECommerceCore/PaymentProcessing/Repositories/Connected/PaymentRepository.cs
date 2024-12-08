using PaymentProcessing.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Repositories.Connected
{
    public class PaymentRepository:IPaymentRepository
    {
        public string _conString;

        private IConfiguration _configuration;
        public PaymentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _conString = this._configuration.GetConnectionString("DefaultConnection");
        }

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
            string query = "SELECT * FROM VsPayments WHERE Id=@Id";
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

                    payment.Id = Convert.ToInt32(data["Id"].ToString());
                    payment.OrderId = Convert.ToInt32(data["OrderId"].ToString());
                    payment.PaymentDate = data["PaymentDate"].ToString();
                    payment.PaymentAmount = Convert.ToInt32(data["PaymentAmount"].ToString());
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

        public async Task<bool> InsertAsync(Payment payment)
        {
            bool status = false;
            SqlConnection conn = new SqlConnection(_conString);
            string query = "INSERT INTO VsPayments(Id, OrderId, PaymentDate, PaymentAmount,PaymentMode, PaymentStatus, TransactionId ) VALUES(@Id,@OrderId,@PaymentDate,@PaymentAmount, @PaymentMode, @PaymentStatus, @TransactionId)";
            SqlCommand cmd = new SqlCommand(query, conn as SqlConnection);

            //Set Parameter for insert Query
            SqlParameter IdParameter = new SqlParameter("@Id", SqlDbType.Int);
            IdParameter.Value = payment.Id;
            SqlParameter OrderIdParameter = new SqlParameter("@OrderId", SqlDbType.Decimal);
            OrderIdParameter.Value = payment.OrderId;
            SqlParameter PaymentDateParameter = new SqlParameter("PaymentDate", SqlDbType.DateTime);
            PaymentDateParameter.Value = payment.PaymentDate;
            SqlParameter PaymentAmountParameter = new SqlParameter("@PaymentAmount", SqlDbType.VarChar);
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
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await conn.CloseAsync();
            }
            return status;
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Payment payment)
        {
            bool status = false;
            SqlConnection conn = new SqlConnection(_conString);
            string query = "UPDATE VsPayments SET Id=@Id , OrderId=@OrderId , PaymentDate=@PaymentDate , PaymentAmount=@PaymentAmount, PaymentMode=@PaymentMode,PaymentStatus=@PaymentStatus, TransactionId= @TransactionId   WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            //Set Paramter for Update Query
            SqlParameter IdParameter = new SqlParameter("@Id", SqlDbType.Int);
            IdParameter.Value = payment.Id;
            SqlParameter OrderIdParameter = new SqlParameter("@OrderId", SqlDbType.Decimal);
            OrderIdParameter.Value = payment.OrderId;
            SqlParameter PaymentDateParameter = new SqlParameter("PaymentDate", SqlDbType.DateTime);
            PaymentDateParameter.Value = payment.PaymentDate;
            SqlParameter PaymentAmountParameter = new SqlParameter("@PaymentAmount", SqlDbType.VarChar);
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
        public async Task<(string status, string Tid)> ExecuteFundTransferProcedure(int customerAccountId, int adminAccountId, decimal amount, string paymentMode)

        {

            string status;

            string Tid = string.Empty;  // Initialize Tid to store the transaction ID

            using (var connection = new SqlConnection(_conString))

            {

                await connection.OpenAsync();

                using (var command = new SqlCommand("VsFundTransfer", connection))

                {

                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure

                    command.Parameters.Add(new SqlParameter("@ToAccountNumber", SqlDbType.VarChar, 20) { Value = customerAccountId.ToString() });

                    command.Parameters.Add(new SqlParameter("@FromAccountNumber", SqlDbType.VarChar, 20) { Value = adminAccountId.ToString() });

                    command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal) { Value = amount });

                    command.Parameters.Add(new SqlParameter("@PaymentMode", SqlDbType.VarChar, 50) { Value = paymentMode });

                    // Output parameter for TransactionId

                    var transactionIdParam = new SqlParameter("@TransactionId", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };

                    command.Parameters.Add(transactionIdParam);

                    try

                    {

                        // Execute the stored procedure

                        await command.ExecuteNonQueryAsync();

                        // Retrieve the TransactionId from the output parameter

                        Tid = transactionIdParam.Value.ToString();

                        // If execution reaches here, it means the procedure ran without errors

                        status = "Complete";

                    }

                    catch (SqlException sqlEx)

                    {

                        // Handle SQL exceptions, such as transaction issues or errors from the stored procedure

                        status = $"SQL Error: {sqlEx.Message}";

                    }

                    catch (Exception ex)

                    {

                        // Handle general exceptions

                        status = $"Error: {ex.Message}";

                    }

                }

            }

            return (status, Tid);

        }






    }
}

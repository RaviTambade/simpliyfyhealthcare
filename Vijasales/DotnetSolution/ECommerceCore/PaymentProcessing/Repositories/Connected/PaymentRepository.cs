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
                    payment.PaymentAmount = Convert.ToInt32(data["PaymentAmount"].ToString());
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

    }
}

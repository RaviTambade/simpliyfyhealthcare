using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace FundTransferTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //string connectionString = "Server=your_server_name;Database=your_database_name;Trusted_Connection=True;";
            string connectionString = @"data source=shc-sql-01.database.windows.net ; database=HangFireCatalog_VG; User Id=tmgreadonly; Password=#p7P>Wzs;";
            
            int customerAccountId = 1;  
            int adminAccountId = 5;     
            decimal amount = 100.00M;   
            string paymentMode = "Debit"; 

            try
            {
                string message = await ExecuteFundTransferProcedure(connectionString, customerAccountId, adminAccountId, amount, paymentMode);
                Console.WriteLine(message);  // Display success message or error
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static async Task<string> ExecuteFundTransferProcedure(string connectionString, int customerAccountId, int adminAccountId, decimal amount, string paymentMode)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("VsFundTransfer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    command.Parameters.Add(new SqlParameter("@CustomerAccountID", SqlDbType.Int) { Value = customerAccountId });
                    command.Parameters.Add(new SqlParameter("@AdminAccountID", SqlDbType.Int) { Value = adminAccountId });
                    command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal) { Value = amount });
                    command.Parameters.Add(new SqlParameter("@PaymentMode", SqlDbType.VarChar, 50) { Value = paymentMode });

                    try
                    {
                        // Execute the stored procedure
                        await command.ExecuteNonQueryAsync();

                        // If execution reaches here, it means the procedure ran without errors
                        return "Payment processed successfully.";
                    }
                    catch (SqlException sqlEx)
                    {
                        // Handle SQL exceptions, such as transaction issues or errors from the stored procedure
                        return $"SQL Error: {sqlEx.Message}";
                    }
                    catch (Exception ex)
                    {
                        // Handle general exceptions
                        return $"Error: {ex.Message}";
                    }
                }
            }
        }
    }
}

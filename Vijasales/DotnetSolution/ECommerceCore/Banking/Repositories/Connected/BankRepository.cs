using Banking.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Repositories.Connected
{
    public class BankRepository:IBankRepository
    {
        public string _conString;

        private IConfiguration _configuration;
        public BankRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _conString = this._configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Account>> GetAllAsync()
        {
            SqlConnection conn = new SqlConnection(_conString);
            string query = "SELECT * FROM VsAccounts";

            SqlCommand cmd = new SqlCommand(query, conn);
            List<Account> Accounts = new List<Account>();
            try
            {
                await conn.OpenAsync();
                IDataReader data = await cmd.ExecuteReaderAsync();
                Console.WriteLine(data);
                while (data.Read())
                {

                    Account account = new Account();
                    account.AccountId = Convert.ToInt32(data["AccountId"].ToString());
                    account.Passcode = data["Passcode"].ToString();
                    account.UserId = Convert.ToInt32(data["UserId"].ToString());
                    account.AccountNumber = data["AccountNumber"].ToString();
                    account.BankName = data["BankName"].ToString();
                    account.IFSCCode = data["IFSCCode"].ToString();
                    account.Balance = Convert.ToDouble(data["Balance"].ToString());
                    Accounts.Add(account);
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
            return Accounts;
        }

        public async Task<Account> GetAccountAsync(string AccountNumber)
        {
            Account account = new Account();
            SqlConnection conn = new SqlConnection(_conString);
            string query = "SELECT * FROM VsAccounts WHERE AccountNumber = @AccountNumber";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter AccountNumberParameter = new SqlParameter("@AccountNumber", SqlDbType.VarChar);
            AccountNumberParameter.Value = AccountNumber;
            cmd.Parameters.Add(AccountNumberParameter);

            try
            {
                await conn.OpenAsync();
                IDataReader data = await cmd.ExecuteReaderAsync();
                if (data.Read())
                {
                    account.AccountId = Convert.ToInt32(data["AccountId"].ToString());
                    account.Passcode = data["Passcode"].ToString();
                    account.UserId = Convert.ToInt32(data["UserId"].ToString());
                    account.AccountNumber = data["AccountNumber"].ToString();
                    account.BankName = data["BankName"].ToString();
                    account.IFSCCode = data["IFSCCode"].ToString();
                    account.Balance = Convert.ToDouble(data["Balance"].ToString());

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
            return account;
        }
    }
}

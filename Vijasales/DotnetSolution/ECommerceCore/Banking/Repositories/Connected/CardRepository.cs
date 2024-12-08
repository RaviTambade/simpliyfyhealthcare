using Banking.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Repositories.Connected
{
    public class CardRepository:ICardRepository
    {
        public string _conString;

        private IConfiguration _configuration;
        public CardRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _conString = this._configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Card>> GetAllAsync()
        {
            SqlConnection conn = new SqlConnection(_conString);
            string query = "SELECT * FROM VsCards";
            SqlCommand cmd = new SqlCommand(query, conn);
            List<Card> cards = new List<Card>();
            try
            {
                await conn.OpenAsync();
                IDataReader data = await cmd.ExecuteReaderAsync();
                while (data.Read())
                {
                    Card card = new Card();
                    card.Id = Convert.ToInt32(data["Id"].ToString());
                    card.Pass = (data["Pass"].ToString());
                    card.CVV = data["CVV"].ToString();
                    card.AccountId = data["AccountId"].ToString();
                    card.CardType = data["CardType"].ToString();
                    card.CreditLimit = Convert.ToDouble(data["CardStatus"].ToString());
                    card.CardNumber = data["CardNumber"].ToString();
                    card.ExpiryDate = data["CardNumber"].ToString();
                    card.AccountNumber = data["AccountNumber"].ToString();

                    cards.Add(card);
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
            return cards;
        }

        public async Task<Card> GetCardAsync(int id)
        {
            Card card = new Card();
            SqlConnection conn = new SqlConnection(_conString);
            string query = "SELECT * FROM VsCards WHERE Id=@Id";
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

                    card.Id = Convert.ToInt32(data["Id"].ToString());
                    card.Pass = (data["Pass"].ToString());
                    card.CVV = data["CVV"].ToString();
                    card.AccountId = data["AccountId"].ToString();
                    card.CardType = data["CardType"].ToString();
                    card.CreditLimit = Convert.ToDouble(data["CardStatus"].ToString());
                    card.CardNumber = data["CardNumber"].ToString();
                    card.ExpiryDate = data["CardNumber"].ToString();
                    card.AccountNumber = data["AccountNumber"].ToString();
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
            return card;
        }

    }
}

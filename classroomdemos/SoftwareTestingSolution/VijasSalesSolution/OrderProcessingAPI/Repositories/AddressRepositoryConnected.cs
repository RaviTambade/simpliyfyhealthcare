using MySql.Data.MySqlClient;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;

namespace Transflower.MembershipRolesMgmt.Repositories.Connected;

public class AddressRepository : IAddressRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public AddressRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString =
            _configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException(nameof(_connectionString));
    }

    public async Task<List<Address>> GetAllAddresses(int userId)
    {
        List<Address> addresses = new List<Address>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;
        try
        {
            string query =
                @"SELECT addresses.id, addresses.area,addresses.landmark,addresses.city,
            addresses.state,addresses.pincode,addresses.addresstype,users.contactnumber,
            CONCAT(users.firstname, ' ', users.lastname) as name  FROM addresses
            INNER JOIN users on addresses.userid=users.id
            WHERE users.id=@userid";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@userid", userId);
            await con.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                Address address = new Address()
                {
                    Id = reader.GetInt32("id"),
                    UserId = userId,
                    Area = reader.GetString("area"),
                    LandMark = reader.GetString("landmark"),
                    City = reader.GetString("city"),
                    State = reader.GetString("state"),
                    PinCode = reader.GetString("pincode"),
                    Name = reader.GetString("name"),
                    ContactNumber = reader.GetString("contactnumber"),
                    AddressType = reader.GetString("addresstype")
                };
                addresses.Add(address);
            }
            await reader.CloseAsync();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await con.CloseAsync();
        }
        return addresses;
    }

    public async Task<Address> GetAddress(int addressId)
    {
        Address address = null;

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;
        try
        {
            string query =
                @"SELECT addresses.id, addresses.userid,addresses.area,addresses.landmark,addresses.city,
            addresses.state,addresses.pincode,addresses.addresstype,users.contactnumber,
            CONCAT(users.firstname, ' ', users.lastname) as name  FROM addresses
            INNER JOIN users on addresses.userid=users.id
            WHERE addresses.id=@addressid";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@addressid", addressId);
            await con.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                address = new Address()
                {
                    Id = reader.GetInt32("id"),
                    UserId = reader.GetInt32("userid"),
                    Area = reader.GetString("area"),
                    LandMark = reader.GetString("landmark"),
                    City = reader.GetString("city"),
                    State = reader.GetString("state"),
                    PinCode = reader.GetString("pincode"),
                    Name = reader.GetString("name"),
                    ContactNumber = reader.GetString("contactnumber"),
                    AddressType = reader.GetString("addresstype")
                };
            }
            await reader.CloseAsync();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await con.CloseAsync();
        }
        return address;
    }

    public async Task<bool> Insert(Address address)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;

        try
        {
            string query =
                @"INSERT INTO addresses(userid,area,landmark,city,state,pincode,addresstype) 
            VALUES(@userid, @area,@landmark, @city,@state,@pincode,@addresstype)";
            MySqlCommand command = new MySqlCommand(query, con);
            await con.OpenAsync();
            command.Parameters.AddWithValue("@userid", address.UserId);
            command.Parameters.AddWithValue("@area", address.Area);
            command.Parameters.AddWithValue("@landmark", address.LandMark);
            command.Parameters.AddWithValue("@city", address.City);
            command.Parameters.AddWithValue("@state", address.State);
            command.Parameters.AddWithValue("@pincode", address.PinCode);
            command.Parameters.AddWithValue("@addresstype", address.AddressType);
            int rowsAffected = await command.ExecuteNonQueryAsync();
            if (rowsAffected > 0)
            {
                status = true;
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await con.CloseAsync();
        }
        return status;
    }

    public async Task<bool> Update(int existingId, Address theAddress)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection(_connectionString);
        try
        {
            string query =
                "UPDATE addresses SET area=@area , landmark=@landmark, city=@city,state=@state, pincode=@pincode ,addresstype=@addresstype WHERE id=@existingId ";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@existingId", theAddress.Id);
            command.Parameters.AddWithValue("@userid", theAddress.UserId);
            command.Parameters.AddWithValue("@area", theAddress.Area);
            command.Parameters.AddWithValue("@landmark", theAddress.LandMark);
            command.Parameters.AddWithValue("@city", theAddress.City);
            command.Parameters.AddWithValue("@state", theAddress.State);
            command.Parameters.AddWithValue("@pincode", theAddress.PinCode);
            command.Parameters.AddWithValue("@addresstype", theAddress.AddressType);
            await con.OpenAsync();
            int rowsAffected = await command.ExecuteNonQueryAsync();
            if (rowsAffected > 0)
            {
                status = true;
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await con.CloseAsync();
        }
        return status;
    }

    public async Task<bool> Delete(int existingId)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;

        try
        {
            string query = "Delete from addresses where id=@existingId";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@existingId", existingId);
            await con.OpenAsync();
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await con.CloseAsync();
        }
        return status;
    }
}

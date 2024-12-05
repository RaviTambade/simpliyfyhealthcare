using MySql.Data.MySqlClient;
using System.Data;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;

namespace Transflower.MembershipRolesMgmt.Repositories.Disconnected;

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
                @"SELECT addresses.id,addresses.addresstype,addresses.area,addresses.landmark,addresses.city,
            addresses.state,addresses.pincode,users.contactnumber,
            CONCAT(users.firstname, ' ', users.lastname) as name  FROM addresses
            INNER JOIN users on addresses.userid=users.id
            WHERE users.id=@userid";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@userid", userId);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();

            await dataAdapter.FillAsync(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Address address = new Address()
                {
                    Id = int.Parse(dataRow["id"].ToString()),
                    UserId = userId,
                    Area = dataRow["area"].ToString(),
                    LandMark = dataRow["landmark"].ToString(),
                    City = dataRow["city"].ToString(),
                    State = dataRow["state"].ToString(),
                    PinCode = dataRow["pincode"].ToString(),
                    Name = dataRow["name"].ToString(),
                    ContactNumber = dataRow["contactnumber"].ToString(),
                    AddressType = dataRow["addresstype"].ToString(),
                };
                addresses.Add(address);
            }
        }
        catch (Exception)
        {
            throw;
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
                @"SELECT addresses.id, addresses.userId,addresses.addresstype,addresses.area,addresses.landmark,addresses.city,
            addresses.state,addresses.pincode,users.contactnumber,
            CONCAT(users.firstname, ' ', users.lastname) as name  FROM addresses
            INNER JOIN users on addresses.userid=users.id
            WHERE addresses.id=@addressid";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@addressid", addressId);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();

            await dataAdapter.FillAsync(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            foreach (DataRow dataRow in dataTable.Rows)
            {
                address = new Address()
                {
                    Id = int.Parse(dataRow["id"].ToString()),
                    UserId = int.Parse(dataRow["userid"].ToString()),
                    Area = dataRow["area"].ToString(),
                    LandMark = dataRow["landmark"].ToString(),
                    City = dataRow["city"].ToString(),
                    State = dataRow["state"].ToString(),
                    PinCode = dataRow["pincode"].ToString(),
                    Name = dataRow["name"].ToString(),
                    ContactNumber = dataRow["contactnumber"].ToString(),
                    AddressType = dataRow["addresstype"].ToString(),
                };
                return address;
            }
        }
        catch (Exception)
        {
            throw;
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

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();

            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
            await dataAdapter.FillAsync(dataSet);
            status = true;
        }
        catch (Exception)
        {
            throw;
        }
        return status;
    }

    public async Task<bool> Update(int existingId, Address theAddress)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection(_connectionString);
        MySqlCommand command = new MySqlCommand();
        command.CommandText = "SELECT * FROM addresses";
        command.Connection = con;
        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
        DataSet dataSet = new DataSet();
        try
        {
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
            await dataAdapter.FillAsync(dataSet);
            DataTable dataTable = dataSet.Tables[0];

            DataColumn[] keycolumn = new DataColumn[1];
            keycolumn[0] = dataTable.Columns["id"];
            dataTable.PrimaryKey = keycolumn;

            DataRow row = dataTable.Rows.Find(existingId);
            row["area"] = theAddress.Area;
            row["landmark"] = theAddress.LandMark;
            row["city"] = theAddress.City;
            row["state"] = theAddress.State;
            row["addresstype"] = theAddress.AddressType;
            row["pincode"] = theAddress.PinCode;
            await dataAdapter.UpdateAsync(dataSet);
            status = true;
        }
        catch (Exception)
        {
            throw;
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
            string query = "SELECT * FROM addresses";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
            await dataAdapter.FillAsync(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            DataColumn[] keycolumn = new DataColumn[1];
            keycolumn[0] = dataTable.Columns["id"];
            dataTable.PrimaryKey = keycolumn;
            DataRow dataRow = dataTable.Rows.Find(existingId);
            dataRow.Delete();
            await dataAdapter.UpdateAsync(dataSet);
            status = true;
        }
        catch (Exception)
        {
            throw;
        }
        return status;
    }
}

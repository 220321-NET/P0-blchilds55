using Microsoft.Data.SqlClient;
using System.Data;

namespace DL;

public class Data : IData
{
    private readonly string _connectionString;

    public Data(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public List<Customer> FindCustomer()
    {
        List<Customer> allCustomers = new List<Customer>();

        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Customer;", connection);

        SqlDataReader dataReader = cmd.ExecuteReader();

        while(dataReader.Read())
        {
            int Id = dataReader.GetInt32(0);
            string Username = dataReader.GetString(1);
            Customer customer = new Customer();
            customer.Name = Username;
            customer.Id = Id;
            allCustomers.Add(customer);
        }
        dataReader.Close();
        connection.Close();        

        return allCustomers;
    }

    public void CreateCustomer(Customer customerToCreate) 
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Customer(Username, Password) VALUES (@Username, @Password)", connection);

        cmd.Parameters.AddWithValue("@Username", customerToCreate.Name);
        cmd.Parameters.AddWithValue("@Password", customerToCreate.Pass);

        cmd.ExecuteScalar();
    }
}

//     public void SendOrder(List<Product> Order)
//     {
//         using SqlConnection connection = new SqlConnection(_connectionString);
//         connection.Open();

//         using SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Orders")


//     }
// }
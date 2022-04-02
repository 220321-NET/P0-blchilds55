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
        connection.Close();
    }

    public int CostOfItemsInCart(Cart value)
    {   
        int cost = 0;

        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Product", connection);

        SqlDataReader dataReader = cmd.ExecuteReader();

        for(int i = 0; i < value.currentCart.Count; i++)
        {
            cmd = new SqlCommand("SELECT * FROM Product WHERE Name = " + $"'{value.currentCart[i].getName}'", connection);
            
            if (dataReader.Read())
            {
                int add = dataReader.GetInt32(2);
                cost += add;
            }
        }
        dataReader.Close();
        connection.Close();

        return cost;
    }
}


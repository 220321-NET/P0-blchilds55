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

        for(int i = 0; i < value.currentCart.Count; i++)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE Product.Name = @name", connection);
            cmd.Parameters.AddWithValue("@name", value.currentCart[i].getName);

            SqlDataReader dataReader = cmd.ExecuteReader();
            
            if (dataReader.Read())
            {
                int add = dataReader.GetInt32(2);
                cost += (add * value.currentCart[i].Amount);
            }
            dataReader.Close();
        }
        connection.Close();

        return cost;
    }

    public List<Product> GetInventory()
    {   
        List<Product> inventoryList = new List<Product>();

        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM Inventory JOIN Product ON Inventory.InventoryId = Product.ProductId", connection);
        
        SqlDataReader dataReader = cmd.ExecuteReader();

        while(dataReader.Read())
        {   
            int Id = dataReader.GetInt32(3);
            int productAmount = dataReader.GetInt32(2);
            string inventoryItem = dataReader.GetString(4);
            Product product = new Product(inventoryItem);
            product.Id = Id;
            product.Amount = productAmount;
            inventoryList.Add(product);
        }
        dataReader.Close();
        connection.Close();

        return inventoryList;
    }

    public int SetDatabaseInventory(Product value)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM Inventory", connection);
        
        cmd = new SqlCommand("UPDATE Inventory SET QuantityInventory = @IUpdate WHERE InventoryId = @id", connection);

        cmd.Parameters.AddWithValue("@IUpdate", value.Amount);
        cmd.Parameters.AddWithValue("@id", value.Id);

        cmd.ExecuteScalar();

        cmd = new SqlCommand("SELECT * FROM Inventory WHERE ProductID = " + $"{value.Id}", connection);
        SqlDataReader dataReader = cmd.ExecuteReader();

        if (dataReader.Read())
        {
            value.Amount = dataReader.GetInt32(2);
        }
        dataReader.Close();
        connection.Close();

        return value.Amount;        
    }

    public void PlaceOrder(int value, Customer customer)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM Orders INSERT INTO Orders(StoreID, CartID, CustomerID, Total) VALUES (@StoreID, @CartID, @CustomerID, @Total)", connection);
        cmd.Parameters.AddWithValue("@StoreID", 1);
        cmd.Parameters.AddWithValue("@CartID", 5);
        cmd.Parameters.AddWithValue("@CustomerID", customer.Id);
        cmd.Parameters.AddWithValue("@Total", value);
        cmd.ExecuteScalar();

        connection.Close();
    }

    public int GetOrderHistory(Customer value) 
    {
        int cost = 0;

        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM Orders WHERE CustomerID = @Id", connection);
        cmd.Parameters.AddWithValue("@Id", value.Id);
        cmd.ExecuteScalar();

        SqlDataReader dataReader = cmd.ExecuteReader();

        while(dataReader.Read())
        {   
            int data = dataReader.GetInt32(4);
            cost += data;
        }
        dataReader.Close();
        connection.Close();

        return cost;
    }
}
    


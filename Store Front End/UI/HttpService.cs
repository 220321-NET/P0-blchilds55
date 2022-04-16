using System.Text.Json;
using System.Text;
using System;
using System.Net.Http;

namespace UI;
public class HttpService
{
    private readonly string _apiBaseUrl = "https://localhost:7198/api/";
    private HttpClient client = new HttpClient();

    public HttpService()
    {
        client.BaseAddress = new Uri(_apiBaseUrl);
    }
    public async Task<Customer> FindCustomerAsync(string userName)
    {
        Customer customer = new Customer();

        try
        {
            HttpResponseMessage response = await client.GetAsync($"Store/{userName}");
            response.EnsureSuccessStatusCode();
            string responseString = await response.Content.ReadAsStringAsync();
            
            customer = JsonSerializer.Deserialize<Customer>(responseString) ?? new Customer();
        }
        catch(HttpRequestException ex)
        {
            Console.WriteLine(ex);
        }
        return customer;
    }
    
    // public void CreateCustomer(string customerName)
    // {

    // }

    public async Task<List<Product>> GetInventoryAsync()
    {
        List<Product> inventoryList = new List<Product>();

        try
        {
            HttpResponseMessage response = await client.GetAsync("Store/Inventory");
            response.EnsureSuccessStatusCode();
            string responseString = await response.Content.ReadAsStringAsync();
            
            inventoryList = JsonSerializer.Deserialize<List<Product>>(responseString) ?? new List<Product>();
        }
        catch(HttpRequestException ex)
        {
            Console.WriteLine(ex);
        }
        return inventoryList;
    }

    public async Task SetDatabaseInventoryAsync(Product product)
    {
        string json = JsonSerializer.Serialize(product);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            HttpResponseMessage response = await client.PutAsync("Store/SetInventory", content);
            response.EnsureSuccessStatusCode();
        }
        catch(HttpRequestException ex)
        {
            Console.WriteLine(ex);
        }
    }

    // public void CostOfItemsInCart()
    // {

    // }

    // public void PlaceOrder()
    // {

    // }

    public async Task<List<Cart>> GetOrderHistoryAsync(int id)
    {
        List<Cart> cart = new List<Cart>();

        try
        {
            HttpResponseMessage response = await client.GetAsync($"Store/Cart/{id}");
            response.EnsureSuccessStatusCode();
            string responseString = await response.Content.ReadAsStringAsync();
            
            cart = JsonSerializer.Deserialize<List<Cart>>(responseString) ?? new List<Cart>();
        }
        catch(HttpRequestException ex)
        {
            Console.WriteLine(ex);
        }
        return cart;
    }
}
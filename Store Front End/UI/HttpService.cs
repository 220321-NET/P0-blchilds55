using System.Text.Json;
using System.Text;
using System;

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

    // public List<Product> GetInventory()
    // {

    // }

    // public void SetDatabaseInventory()
    // {

    // }

    // public void CostOfItemsInCart()
    // {

    // }

    // public void PlaceOrder()
    // {

    // }

    // public void GetOrderHistory()
    // {
        
    // }
}
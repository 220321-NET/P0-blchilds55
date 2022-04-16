namespace UI;
using System.ComponentModel.DataAnnotations;

public class SignUp : Collection
{
    public async override Task Start(HttpService _httpService)
    {
        Console.WriteLine("Enter a username:");
        string customerName = ReadStuff();
            
        // _httpService.CreateCustomer(customerName);
        await new MenuFactory().GetMenu("login").Start();
    }
}
namespace UI;
using System.ComponentModel.DataAnnotations;

public class SignUp : Collection
{
    public async override void Start(HttpService _httpService)
    {
        Console.WriteLine("Enter a username:");
        string customerName = ReadStuff();
            
        // _httpService.CreateCustomer(customerName);
        new MenuFactory().GetMenu("login").Start();
    }
}
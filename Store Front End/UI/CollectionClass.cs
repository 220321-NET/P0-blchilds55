namespace UI;
using System.ComponentModel.DataAnnotations;

public class Collection : IMenu
{
    public virtual async void Start() {}
    public virtual async void Start(HttpService httpService) {}
    public virtual async void Start(HttpService httpService, Customer value1) {}

    public string ReadStuff() 
    {
        TryAgain:
        string input = Console.ReadLine()!.Trim();

        if(String.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input, try again");
            goto TryAgain;
        }
        else
        {
            return input;
        }
    }
}
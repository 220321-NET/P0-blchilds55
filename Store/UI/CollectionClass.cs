namespace UI;
using System.ComponentModel.DataAnnotations;

public class Collection : IMenu
{
    public virtual void Start() {}
    public virtual void Start(IStoreBL _bl) {}
    public virtual void Start(IStoreBL value0, Customer value1) {}

    public string ReadStuff() 
    {
        TryAgain:
        string input = Console.ReadLine()!;

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
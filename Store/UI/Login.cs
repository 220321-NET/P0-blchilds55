namespace UI;

public class Login : IMenu
{
    public void Start() {}
    public void Start(IStoreBL _bl)
    {
        Console.WriteLine("Enter your username:");
        string? input = Console.ReadLine();

        List<Customer> customers = _bl.FindCustomer();

        if (customers.Exists(x => x.Name == input)) 
        {
            Console.WriteLine("Welcome " + $"{input}" + ", please choose from the following menu:");
            new MenuFactory().GetMenu("storemenu").Start(_bl);
        }
        else
        {
            Console.WriteLine("That username does not exist. Please sign up here:");
            new MenuFactory().GetMenu("signup").Start(_bl);
        }  
    }
}

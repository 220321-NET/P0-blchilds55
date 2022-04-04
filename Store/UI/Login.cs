namespace UI;

public class Login : Collection
{
    public override void Start(IStoreBL _bl)
    {
        Console.WriteLine("Enter your username:");
        string input = ReadStuff();

        List<Customer> customers = _bl.FindCustomer();

        if (customers.Exists(x => x.Name == input)) 
        {
            int customerIndex = customers.FindIndex(x => x.Name == input);

            Console.WriteLine("Welcome " + $"{customers[customerIndex].Name}" + ", please choose from the following menu:");
            new MenuFactory().GetMenu("storemenu").Start(_bl, customers[customerIndex]);
        }
        else
        {
            Console.WriteLine("That username does not exist. Please sign up here:");
            new MenuFactory().GetMenu("signup").Start(_bl);
        }  
    }
}

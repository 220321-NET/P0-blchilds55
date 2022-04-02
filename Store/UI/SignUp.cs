namespace UI;
using System.ComponentModel.DataAnnotations;

public class SignUp : IMenu
{
    public void Start() {}
    public void Start(IStoreBL _bl)
    {
        Customer customerToCreate = new Customer();

        EnterUsername:
            Console.WriteLine("Enter a username:");
            string? input = Console.ReadLine();

            try
            {
                customerToCreate.Name = input!;
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.Message);
                goto EnterUsername;
            }
        
        EnterPassword:
            Console.WriteLine("Enter a password:");
            input = Console.ReadLine();

            try
            {
                customerToCreate.Pass = input!;
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.Message);
                goto EnterPassword;
            }
            
            _bl.CreateCustomer(customerToCreate);
    }
}
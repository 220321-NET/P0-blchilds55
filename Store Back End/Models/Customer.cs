namespace Models;
using System.ComponentModel.DataAnnotations;

public class Customer : CommonData
{
    private string name = "";
    private string password = "";
    public string Name 
    { 
        get => name; 
        set
        {
            if(String.IsNullOrWhiteSpace(value))
            {
                throw new ValidationException("Name cannot be empty");
            }
            name = value;
        } 
    }

    public string Pass 
    {
        get => password;
        set
        {
            if(String.IsNullOrWhiteSpace(value))
            {
                throw new ValidationException("Password cannot be empty");
            }
            password = value;
        }
    }
}

namespace UI;

public class MenuFactory
{
    public IMenu GetMenu(string menuString)
    {
        string connectionString = File.ReadAllText("./connectionString.txt");
        HttpService httpService = new HttpService();
        
        switch (menuString)
        {
            case "main":
                return new MainMenu(httpService);
            case "login":
                return new Login();
            case "signup":
                return new SignUp();
            case "manager":
                return new Manager();
            case "storemenu":
                return new StoreMenu();
            default:
                return new MainMenu(httpService);
        }
    }
}
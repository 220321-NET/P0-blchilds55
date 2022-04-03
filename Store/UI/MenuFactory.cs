namespace UI;

public class MenuFactory
{
    public IMenu GetMenu(string menuString)
    {
        string connectionString = File.ReadAllText("./connectionString.txt");
        IData repo = new Data(connectionString);
        IStoreBL bl = new StoreBL(repo);
        
        switch (menuString)
        {
            case "main":
                return new MainMenu(bl);
            case "login":
                return new Login();
            case "signup":
                return new SignUp();
            case "manager":
                return new Manager();
            case "storemenu":
                return new StoreMenu();
            default:
                return new MainMenu(bl);
        }
    }
}
namespace UI;

public class MainMenu : Collection
{
    private readonly HttpService _httpService;

    public MainMenu(HttpService httpService)
    {
        _httpService = httpService;
    }

    public async override void Start() 
    {   
        string input;
        do
        {
            Console.WriteLine("88888888888888888888888888888888888888");
            Console.WriteLine("||  Welcome to the Double R Diner   ||");
            Console.WriteLine("88888888888888888888888888888888888888");
            Console.WriteLine("||  [1] Login         [2] Sign-Up   ||");
            Console.WriteLine("||          [x] to Exit             ||");
            Console.WriteLine("88888888888888888888888888888888888888");   
            
            input = ReadStuff();

            switch (input)
            {
                case "1": 
                    new MenuFactory().GetMenu("login").Start(_httpService);
                    break;

                case "2": 
                    new MenuFactory().GetMenu("signup").Start(_httpService);
                    break;

                case "norma":
                    new MenuFactory().GetMenu("manager").Start(_httpService);
                    break;
            }
        } while(input != "x");
        
        Console.WriteLine("Goodbye!");
    }
}

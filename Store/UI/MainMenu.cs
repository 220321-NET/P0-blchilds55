namespace UI;

public class MainMenu : Collection
{
    private readonly IStoreBL _bl;

    public MainMenu(IStoreBL bL)
    {
        _bl = bL;
    }

    public override void Start() 
    {
            Console.WriteLine("88888888888888888888888888888888888888");
            Console.WriteLine("||  Welcome to the Double R Diner   ||");
            Console.WriteLine("88888888888888888888888888888888888888");
            Console.WriteLine("||  [1] Login         [2] Sign-Up   ||");
            Console.WriteLine("88888888888888888888888888888888888888");   
            
            string input = ReadStuff();

            switch (input)
            {
                case "1": 
                    new MenuFactory().GetMenu("login").Start(_bl);
                    break;

                case "2": 
                    new MenuFactory().GetMenu("signup").Start(_bl);
                    break;

                case "norma":
                    new MenuFactory().GetMenu("manager").Start(_bl);
                    break;
            }
    }
}
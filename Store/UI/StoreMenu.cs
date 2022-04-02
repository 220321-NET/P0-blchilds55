namespace UI;

public class StoreMenu : IMenu {
    public void Start() {}

    public void Start(IStoreBL _bl) 
    {
        Cart cart = new Cart();
        string? input = "";

        Console.WriteLine("8888888888888888888888888888888888888888888888888888888888888888888888");
        Console.WriteLine("|| [1] Coffee 1.75$                     [4] French Toast $6.50      ||");
        Console.WriteLine("|| [2] 2 Eggs, Any Style $4.00          [5] Pancakes $5.75          ||");
        Console.WriteLine("|| [3] Steak $9.95                      [6] Famous Cherry Pie $2.50 ||");
        Console.WriteLine("||                         [x] to Exit                              ||");                    
        Console.WriteLine("8888888888888888888888888888888888888888888888888888888888888888888888");
        
        do
        {   
            Console.WriteLine("Enter a number to order or x to Exit:");
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Product coffee = new Product("Coffee");
                    AddToCart(coffee, cart);
                    break;
                case "2":
                    Product eggs = new Product("Eggs");
                    AddToCart(eggs, cart);
                    break;
                case "3":
                    Product steak = new Product("Steak");
                    AddToCart(steak, cart);
                    break;
                case "4":
                    Product frenchtoast = new Product("French Toast");
                    AddToCart(frenchtoast, cart);
                    break;
                case "5":
                    Product pancakes = new Product("Pancakes");
                    AddToCart(pancakes, cart);
                    break;
                case "6":
                    Product cherrypie = new Product("Cherry Pie");
                    AddToCart(cherrypie, cart);
                    break;
            }
        } while (input != "x");
    }
    public Cart AddToCart(Product value, Cart cart)
    {
        cart.currentCart.Add(value);
        Console.WriteLine($"{value.getName} " + "added to cart");

        return cart;
    }
}
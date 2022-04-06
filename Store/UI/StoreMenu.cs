namespace UI;

public class StoreMenu : Collection {
    
    public override void Start(IStoreBL _bl, Customer value) 
    {
        Cart cart = new Cart();
        List<Product> inventoryList =_bl.GetInventory();
        string input = "";

        Console.WriteLine("88888888888888888888888888888888888888888888888888888888888888888888888");
        Console.WriteLine("|| [1] Coffee $2.00                     [4] French Toast $7.00       ||");
        Console.WriteLine("|| [2] 2 Eggs, Any Style $4.00          [5] Pancakes $6.00           ||");
        Console.WriteLine("|| [3] Steak $10.00                     [6] Famous Cherry Pie $3.00  ||");
        Console.WriteLine("|| [r] to Review                        [x] to Exit                  ||");                    
        Console.WriteLine("88888888888888888888888888888888888888888888888888888888888888888888888");
        
        do
        {   
            Console.WriteLine("Enter a number to order, r to see order history, or x to Exit:");
            input = ReadStuff();

            switch (input)
            {
                case "1":
                    Product coffee = new Product("Coffee");
                    AddToCart(coffee, cart, input, inventoryList, _bl);
                    break;
                case "2":
                    Product eggs = new Product("Eggs");
                    AddToCart(eggs, cart, input, inventoryList, _bl);
                    break;
                case "3":
                    Product steak = new Product("Steak");
                    AddToCart(steak, cart, input, inventoryList, _bl);
                    break;
                case "4":
                    Product frenchtoast = new Product("French Toast");
                    AddToCart(frenchtoast, cart, input, inventoryList, _bl);
                    break;
                case "5":
                    Product pancakes = new Product("Pancakes");
                    AddToCart(pancakes, cart, input, inventoryList, _bl);
                    break;
                case "6":
                    Product cherrypie = new Product("Cherry Pie");
                    AddToCart(cherrypie, cart, input, inventoryList, _bl);
                    break;
                case "r":
                    int orderHistory = _bl.GetOrderHistory(value);
                    Console.WriteLine("Order history: " + $"{orderHistory}$");
                    continue;
            }
        } while (input != "x");
        
        //
        // DON'T FORGET THIS IS HERE. 
        //

        if (cart.currentCart.Count > 0)
        {
            SendOrder(cart, _bl, value);
        }
        else
        {
            Console.WriteLine("Returning to main menu");
            new MenuFactory().GetMenu("main").Start(_bl);
        }
    }
    public Cart AddToCart(Product value, Cart cart, string itemID, List<Product> inventoryList, IStoreBL _bl)
    {   
        ChooseAmount:
        Console.WriteLine("How many orders of " + $"{value.getName}" + " would you like?");
        string input = ReadStuff();

        value.Amount = Convert.ToInt32(input);
        value.Id = Convert.ToInt32(itemID);

        if (inventoryList.Exists(x => x.getName == value.getName)) 
            {
                int itemIndex = inventoryList.FindIndex(x => x.getName == value.getName);

                if (value.Amount > inventoryList[itemIndex].Amount)
                {
                    Console.WriteLine("Not enough stock, there are " + $"{inventoryList[itemIndex].Amount}" + " orders of " + $"{inventoryList[itemIndex].getName}" + " left");
                    goto ChooseAmount;
                }
                else
                {
                    Product product = new Product(value.getName);
                    product.Id = itemIndex + 1;
                    product.Amount = inventoryList[itemIndex].Amount - value.Amount;
                    _bl.SetDatabaseInventory(product);
                    
                    cart.currentCart.Add(value);        
                    Console.WriteLine($"{value.getName} " + "added to cart");
                }
        }
        return cart;
    }
    public void SendOrder(Cart cart, IStoreBL _bl, Customer value)
    {   
        int cost = _bl.CostOfItemsInCart(cart);
        
        Console.WriteLine("Your order total is: " + $"{cost}" + "$");
        Console.WriteLine("Do you wish to place this order? [1] Yes [2] No"); // review order and remove product maybe
        string input = ReadStuff();

        if (input == "1")
        {
            Console.WriteLine("Thank you for shopping at Double R diner! Your order will be delivered shortly. Returning to main menu");
            _bl.PlaceOrder(cost, value);
            new MenuFactory().GetMenu("main").Start(_bl);
        }
        else
        {
            Console.WriteLine("Returning to main menu");
            new MenuFactory().GetMenu("main").Start(_bl);
        }
        
    }
}
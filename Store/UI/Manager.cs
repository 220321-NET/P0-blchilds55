namespace UI;

public class Manager : Collection 
{
    public override void Start(IStoreBL _bl)
    {
        Console.WriteLine("88888888888888888888888888");
        Console.WriteLine("|| [1] View Inventory   ||");
        Console.WriteLine("|| [2] Update Inventory ||");
        Console.WriteLine("88888888888888888888888888");

        string? input = Console.ReadLine();

        switch (input)
        {
            case "1":
                List<Product> inventoryList =_bl.GetInventory();
                ViewInventory(inventoryList);
                break;
            case "2":
                chooseInventory(_bl);
                break;
        }
    }
    public void ViewInventory(List<Product> inventoryList)
    {
        
        for(int i = 0; i < inventoryList.Count; i++)
        {
            Console.WriteLine("[" + $"{inventoryList[i].Id}" + "] " + $"{inventoryList[i].getName}" + ": " + $"{inventoryList[i].Amount}");
        }
    }

    public void chooseInventory(IStoreBL _bl)
    {   
        string? chooseProduct = "";
        
        do
        {
            Console.WriteLine("Choose inventory item by index to update, i to view inventory, or x to exit");
            chooseProduct = Console.ReadLine();

            Product product;

            switch (chooseProduct)
            {
                case "1": 
                    product = new("Coffee");
                    SendToDataLayer(_bl, product, chooseProduct);
                    break;
                case "2":
                    product = new("Eggs");
                    SendToDataLayer(_bl, product, chooseProduct);
                    break;
                case "3":
                    product = new("Steak");
                    SendToDataLayer(_bl, product, chooseProduct);
                    break;
                case "4":
                    product = new("French Toast");
                    SendToDataLayer(_bl, product, chooseProduct);
                    break;
                case "5":
                    product = new("Pancakes");
                    SendToDataLayer(_bl, product, chooseProduct);
                    break;
                case "6":
                    product = new("Cherry Pie");
                    SendToDataLayer(_bl, product, chooseProduct);
                    break;
                case "i":
                    List<Product> inventoryList =_bl.GetInventory();
                    ViewInventory(inventoryList);
                    break;
                case "x":
                    break;
            }
        } while(chooseProduct != "x");
    }

    public void SendToDataLayer(IStoreBL _bl, Product product, string chooseProduct)
    {
        string? addAmount = "";
        int newAmount = 0;

        Console.WriteLine("Enter the amount of inventory:");
        addAmount = Console.ReadLine();

        product.Id = Convert.ToInt32(chooseProduct);
        product.Amount = Convert.ToInt32(addAmount);
        newAmount = _bl.SetDatabaseInventory(product);      
    }
}

        // Console.WriteLine("88888888888888888888888888888888888888888888888888888888888888888888888");
        // Console.WriteLine("|| [1] Coffee $2.00                     [4] French Toast $7.00       ||");
        // Console.WriteLine("|| [2] 2 Eggs, Any Style $4.00          [5] Pancakes $6.00           ||");
        // Console.WriteLine("|| [3] Steak $10.00                     [6] Famous Cherry Pie $3.00  ||");
        // Console.WriteLine("||                          [x] to Exit                              ||");                    
        // Console.WriteLine("88888888888888888888888888888888888888888888888888888888888888888888888");
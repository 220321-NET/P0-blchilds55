namespace UI;

public class Manager : Collection 
{
    public override void Start(IStoreBL _bl)
    {
        Console.WriteLine("888888888888888888888888888");
        Console.WriteLine("|| [1] View Inventory    ||");
        Console.WriteLine("|| [2] Update Inventory  ||");
        Console.WriteLine("888888888888888888888888888");

        string? input = Console.ReadLine();

        switch (input)
        {
            case "1":
                List<Product> inventoryList =_bl.GetInventory();
                ViewInventory(inventoryList);
                break;
            case "2":
                break;
        }
    }
    public void ViewInventory(List<Product> inventoryList)
    {
        for(int i = 0; i < inventoryList.Count; i++)
        {
            Console.WriteLine($"{inventoryList[i].getName}" + ": " + $"{inventoryList[i].Amount}");
        }
    }
}
namespace BL;

public interface IStoreBL
{
    public List<Customer> FindCustomer();
    public void CreateCustomer(Customer customerToCreate);
    public int CostOfItemsInCart(Cart value);
    public List<Product> GetInventory();
    public int SetDatabaseInventory(Product value);
    public void PlaceOrder(int value, Customer customer);
    public int GetOrderHistory(Customer value);
}
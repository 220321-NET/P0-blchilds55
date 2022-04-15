namespace BL;

public interface IStoreBL
{
    public Task<Customer> FindCustomerAsync(string userName);
    public void CreateCustomer(string customerName);
    public int CostOfItemsInCart(Cart value);
    public List<Product> GetInventory();
    public int SetDatabaseInventory(Product value);
    public void PlaceOrder(Cart cart, Customer customer, int cost);
    public List<Cart> GetOrderHistory(int value);
}
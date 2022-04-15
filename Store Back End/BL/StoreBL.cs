namespace BL;
using DL;

public class StoreBL : IStoreBL
{
    private readonly IData _repo;
    public StoreBL(IData repo)
    {
        _repo = repo;
    }
    public async Task<Customer> FindCustomerAsync(string userName) 
    {
        return await _repo.FindCustomerAsync(userName);
    }
    public void CreateCustomer(string customerName) 
    {
        _repo.CreateCustomer(customerName);
    }

    public int CostOfItemsInCart(Cart value)
    {
        return _repo.CostOfItemsInCart(value);
    }

    public List<Product> GetInventory()
    {
        return _repo.GetInventory();
    }

    public int SetDatabaseInventory(Product value)
    {
        return _repo.SetDatabaseInventory(value);
    }

    public void PlaceOrder(Cart cart, Customer customer, int cost)
    {
        _repo.PlaceOrder(cart, customer, cost);
    }

    public List<Cart> GetOrderHistory(int value)
    {
        return _repo.GetOrderHistory(value);
    }
}


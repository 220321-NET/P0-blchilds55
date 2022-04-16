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

    public async Task<List<Product>> GetInventoryAsync()
    {
        return await _repo.GetInventoryAsync();
    }

    public async Task SetDatabaseInventoryAsync(Product value)
    {
        await _repo.SetDatabaseInventoryAsync(value);
    }

    public void PlaceOrder(Cart cart, Customer customer, int cost)
    {
        _repo.PlaceOrder(cart, customer, cost);
    }

    public async Task<List<Cart>> GetOrderHistoryAsync(int value)
    {
        return await _repo.GetOrderHistoryAsync(value);
    }
}


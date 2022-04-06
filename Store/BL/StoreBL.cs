namespace BL;
using DL;

public class StoreBL : IStoreBL
{
    private readonly IData _repo;
    public StoreBL(IData repo)
    {
        _repo = repo;
    }
    public List<Customer> FindCustomer() 
    {
        return _repo.FindCustomer();
    }
    public void CreateCustomer(Customer customerToCreate) 
    {
        _repo.CreateCustomer(customerToCreate);
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

    public void PlaceOrder(int value, Customer customer)
    {
        _repo.PlaceOrder(value, customer);
    }

    public int GetOrderHistory(Customer value)
    {
        return _repo.GetOrderHistory(value);
    }
}


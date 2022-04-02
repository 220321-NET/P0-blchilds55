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
}


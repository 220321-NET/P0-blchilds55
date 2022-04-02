namespace BL;

public interface IStoreBL
{
    public List<Customer> FindCustomer();
    public void CreateCustomer(Customer customerToCreate);
}
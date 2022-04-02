namespace DL;

public interface IData
{
        public List<Customer> FindCustomer();
        public void CreateCustomer(Customer customerToCreate);
        public int CostOfItemsInCart(Cart value);
        //public void SendOrder(List<Product> Order);
}
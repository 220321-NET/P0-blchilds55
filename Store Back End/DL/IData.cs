namespace DL;

public interface IData
{
        public Task<Customer> FindCustomerAsync(string userName);
        public void CreateCustomer(string customerName);
        public int CostOfItemsInCart(Cart value);
        public Task<List<Product>> GetInventoryAsync();
        public Task SetDatabaseInventoryAsync(Product value);
        public void PlaceOrder(Cart cart, Customer customer, int cost);
        public Task<List<Cart>> GetOrderHistoryAsync(int value);
}
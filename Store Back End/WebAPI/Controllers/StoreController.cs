using Microsoft.AspNetCore.Mvc;
using BL;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreBL _bl;
        public StoreController(IStoreBL bl)
        {
            _bl = bl;
        }
        
        [HttpGet("{userName}")]
        public async Task<Customer> GetCustomerAsync(string userName)
        {
            Customer customer = new Customer();

            customer = await _bl.FindCustomerAsync(userName);
            return customer;
        }

        [HttpPut("Cost")]
        public async Task<int> PutCostOfItemsInCartAync(Cart value)
        {
            return await _bl.CostOfItemsInCartAsync(value);
        }
       
        [HttpGet("Cart/{id}")]
        public async Task<List<Cart>> GetOrderHistoryAsync(int id)
        {
            return await _bl.GetOrderHistoryAsync(id);          
        }

        [HttpGet("Inventory")]
        public async Task<List<Product>> GetInventoryAsync()
        {
            return await _bl.GetInventoryAsync();
        }
        // // POST api/<StoreController>
        // [HttpPost]
        // public ActionResult Post([FromBody] string customerName, [FromBody] string customerPass)
        // {
        //     if (customerName.Length > 0 & customerPass.Length > 0)
        //     {
        //         _bl.CreateCustomer(customerName, customerPass);
        //         return Ok();
        //     }
        //     return NoContent();
        // }

        // PUT api/<StoreController>/5
        [HttpPost("PlaceOrder")]
        public async Task PostOrderAsync(Tuple<Cart, Customer, int> OrderToBePlaced)
        {
            Cart cart = new Cart();
            Customer customer = new Customer();
            int cost;

            cart = OrderToBePlaced.Item1;
            customer = OrderToBePlaced.Item2;
            cost = OrderToBePlaced.Item3;

            await _bl.PlaceOrderAsync(cart, customer, cost);
        }
        [HttpPut("SetInventory")]
        public async Task PutInventoryAsync(Product product)
        {
            await _bl.SetDatabaseInventoryAsync(product);
        }

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        // DELETE api/<StoreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

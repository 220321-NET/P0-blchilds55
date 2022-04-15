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
        
        [HttpGet("userName")]
        public async Task<Customer> GetAsync(string userName)
        {
            Customer customer = new Customer();

            customer = await _bl.FindCustomerAsync(userName);
            return customer;
        }
        // // GET api/<StoreController>/5
        // [HttpGet("{id}")]
        // public ActionResult<List<Cart>> Get(int id)
        // {
        //     if (id <= 0)
        //     {
        //         return BadRequest();
        //     }
        //     else
        //     {
        //         return _bl.GetOrderHistory(id);
        //     }            
        // }

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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StoreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

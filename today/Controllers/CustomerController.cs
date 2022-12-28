using Microsoft.AspNetCore.Mvc;
using today.Entities;
using today.Repositories;

namespace today.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("getCustomerList")]
        public async Task<List<Customer>> GetCustomerListAsync()
        {
            try
            {
                return await customerService.GetCustomerListAsync();
            }
            catch
            {
                throw;
            }
        }

     /*   [HttpGet("getCustomerById")]
        public async Task<IEnumerable<Customer>> GetCustomerByIdAsync(int Id)
        {
            try
            {
                var response = await customerService.GetCustomerByIdAsync(Id);
                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch
            {
                throw;
            }
        }
*/
        
        [HttpPost("addCustomer")]
        public async Task<IActionResult> AddCustomerAsync(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await customerService.AddCustomerAsync(customer);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
     /*   [HttpPut("updateCustomer")]
        public async Task<IActionResult> UpdateCustomertAsync(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await customerService.UpdateCustomertAsync(customer);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }
*/
        
       /* [HttpDelete("deleteCustomer")]
        public async Task<int> DeleteCustomerAsync(int Id)
        {
            try
            {
                var response = await customerService.DeleteCustomerAsync(Id);
                return response;
            }
            catch
            {
                throw;
            }
        }*/
    }
}

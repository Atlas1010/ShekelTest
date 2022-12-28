using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using today.Entities;
using today.Repositories;

namespace today.Controllers
{
    public class FactoriesToCustomerController : Controller
    {
  private readonly IFactoriesToCustomerService iFactoriesToCustomer;

        public FactoriesToCustomerController(IFactoriesToCustomerService factoriesToCustomer)
        {
            this.iFactoriesToCustomer = factoriesToCustomer;
        }
       
            [HttpGet("getIFactoriesToCustomerList")]
        public async Task<List<FactoriesToCustomer>> GetFactoriesToCustomerListAsync()
        {
            try
            {
                return await iFactoriesToCustomer.GetFactoriesToCustomerListAsync();
            }
            catch
            {
                throw;
            }
        }

  /*      [HttpGet("getFactoriesToCustomerById")]
        public async Task<IEnumerable<FactoriesToCustomer>> GetFactoriesToCustomerByIdAsync(int Id)
        {
            try
            {
                var response = await iFactoriesToCustomer.GetFactoriesToCustomerByIdAsync(Id);
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
        }*/

   /*     [HttpPost("addfactoriesToCustomer")]
        public async Task<IActionResult> AddFactoriesToCustomerAsync(FactoriesToCustomer factoriesToCustomer)
        {
            if (factoriesToCustomer == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await iFactoriesToCustomer.AddFactoriesToCustomerAsync(factoriesToCustomer);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
   /*

   /*     [HttpPut("updateFactoriesToCustomer")]
     public async Task<IActionResult> UpdateFactoriesToCustomerAsync(FactoriesToCustomer factoriesToCustomer)
        {
            if (factoriesToCustomer == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await iFactoriesToCustomer.UpdateFactoriesToCustomerAsync(factoriesToCustomer);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }*/

  /*      [HttpDelete("deleteFactoriesToCustomer")]
        public async Task<int> DeleteCustomerAsync(int Id)
        {
            try
            {
                var response = await iFactoriesToCustomer.DeleteFactoriesToCustomerAsync(Id);
                return response;
            }
            catch
            {
                throw;
            }
        }*/

       [HttpPost("AddParams")]

        public async Task<IActionResult> AddParams(int customerId,string name,string address,string phone,int groupCode,int factoryCode)
        {
            if (groupCode==0 || factoryCode==0)
            {
                return BadRequest();
            }

            try
            {
                var response = await iFactoriesToCustomer.AddParams( name,  address,  phone,  groupCode,  factoryCode);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
        [HttpGet("GetGroupsCustomer")]
        public async Task<List<GroupCustomers>> GetGroupsCustomers()
        {
            try
            {
                return await iFactoriesToCustomer.GetGroupCustomersListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}

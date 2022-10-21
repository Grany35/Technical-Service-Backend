using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Business.Abstract;
using Service.Entities.Concrete;

namespace Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            await _customerService.AddCustomerAsync(customer);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _customerService.GetAllAsync();
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Business.Abstract;
using Service.Core.Extensions;
using Service.Entities.Concrete;
using Service.Entities.Dtos;

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
        public async Task<IActionResult> AddCustomer(CustomerCreateDto customerCreateDto)
        {
            var result = await _customerService.AddCustomerAsync(customerCreateDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _customerService.GetAllAsync();

            return Ok(result);
        }
    }
}

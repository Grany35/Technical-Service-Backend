using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Business.Abstract;
using Service.Entities.Concrete;
using Service.Entities.Dtos;

namespace Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceInformationsController : ControllerBase
    {
        private readonly IServiceInformationService _serviceInformationService;

        public ServiceInformationsController(IServiceInformationService serviceInformationService)
        {
            _serviceInformationService = serviceInformationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _serviceInformationService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateService(CreateServiceDto createServiceDto)
        {
            _serviceInformationService.AddService(createServiceDto);
            return NoContent();
        }

        [HttpDelete("{serviceId}")]
        public IActionResult DeleteService(int serviceId)
        {
            _serviceInformationService.DeleteService(serviceId);
            return NoContent();

        }
    }
}

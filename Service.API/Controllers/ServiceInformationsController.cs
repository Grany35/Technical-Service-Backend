using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Business.Abstract;
using Service.Core.Utilities.Params;
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
        public async Task<IActionResult> GetAll([FromQuery]ServiceInformationParams serviceParams)
        {
            var result = await _serviceInformationService.GetAllAsync(serviceParams);
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

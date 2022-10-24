using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Business.Abstract;
using Service.Core.Extensions;
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
        public async Task<IActionResult> GetAll([FromQuery] ServiceInformationParams serviceParams)
        {
            var result = await _serviceInformationService.GetAllAsync(serviceParams);

            Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            await _serviceInformationService.AddService(createServiceDto);
            return NoContent();
        }

        [HttpDelete("{serviceId}")]
        public async Task<IActionResult> DeleteService(int serviceId)
        {
            await _serviceInformationService.DeleteService(serviceId);
            return NoContent();

        }
    }
}

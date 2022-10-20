using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Business.Abstract;
using Service.Entities.Concrete;

namespace Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly IPartService _partService;

        public PartsController(IPartService partService)
        {
            _partService = partService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _partService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{partId}")]
        public async Task<IActionResult> GetById(int partId)
        {
            var result = await _partService.GetByIdAsync(partId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Part part)
        {
            _partService.Add(part);
            return NoContent();
        }

        [HttpDelete("{partId}")]
        public IActionResult Delete(int partId)
        {
            _partService.Delete(partId);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(Part part)
        {
            _partService.Update(part);
            return NoContent();
        }
    }
}

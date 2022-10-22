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

        
    }
}

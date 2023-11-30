using APIArchitectureWithRelations.Service_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIArchitectureWithRelations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemDetailController : ControllerBase
    {
        private readonly ISystemDetailService systemDetailsService;
        public SystemDetailController(ISystemDetailService _systemDetailsService)
        { 
            systemDetailsService = _systemDetailsService;
        }
    }
}

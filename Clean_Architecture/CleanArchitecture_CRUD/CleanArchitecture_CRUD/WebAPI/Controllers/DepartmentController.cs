using Application.DepartmentCQRS.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class DepartmentController : APIControllerBase
    {
        [HttpGet]
        [Route("GetAllDepartments")]
        public async Task<ActionResult> GetAllDepartments()
        {
            var gotAllDepartments = await Mediator.Send(new GetAllDepartments());
            return Ok(gotAllDepartments);
        }
    }
}

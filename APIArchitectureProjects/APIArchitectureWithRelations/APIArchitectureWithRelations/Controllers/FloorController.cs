using APIArchitectureWithRelations.DTOs;
using APIArchitectureWithRelations.Service_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIArchitectureWithRelations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private readonly IFloorService floorService;
        public FloorController(IFloorService _floorService)
        {
            floorService = _floorService; 
        }



        [HttpPost]
        [Route("addFloor")]
        public async Task<ActionResult> Add_Floor([FromBody] AddFloorDTO addFloorDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            await floorService.AddFloor_Service(addFloorDTO);
            return Ok("Floor Added!!");

        }

        [HttpGet]
        [Route("GetFloorSpecificEmployees")]
        public async Task<ActionResult> GetFloorSpecificEmployees(int floorID)
        {

            var GetFloorSpecificEmployees = await floorService.GetFloorSpecificEmployees_Service(floorID);
            return Ok(GetFloorSpecificEmployees);

        }

    }
}

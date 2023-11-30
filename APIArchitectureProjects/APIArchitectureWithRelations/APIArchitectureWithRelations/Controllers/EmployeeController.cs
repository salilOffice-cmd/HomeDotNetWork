using APIArchitectureWithRelations.DTOs;
using APIArchitectureWithRelations.Service_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIArchitectureWithRelations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }

        [HttpGet]
        [Route("getEmployeeByID/{empID}")]
        [ActionName(nameof(GetEmployeeByID))]
        public async Task<ActionResult> GetEmployeeByID(int empID)
        {
            var gotEmployee = await employeeService.GetEmployeeByID_Service(empID);
            return Ok(gotEmployee);

        }



        [HttpPost]
        [Route("addEmployee")]
        public async Task<ActionResult> Add_Employee([FromBody] AddEmployeeDTO addEmployeeDTO)
        {
            var gotAddedEmployee= await employeeService.AddEmployee_Service(addEmployeeDTO);
            return Ok("Employee Added!!");
            //return Ok(gotAddedEmployee);
            //return CreatedAtAction(nameof(GetEmployeeByID), new { id = gotAddedEmployee.EmployeeId }, gotAddedEmployee);

        }

        // Agar mein koyi constraint ko violate krta hu
        // Toh identity column count krke skip krega
        //
        [HttpGet]
        [Route("getEmployeesWithFloor")]
        public async Task<ActionResult> GetEmployeesWithFloor()
        {
            var gotEmployees = await employeeService.GetEmployeesWithFloor_Service();
            return Ok(gotEmployees);

        }


        [HttpGet]
        [Route("GetEmployeesWithFloor_TabularFormat")]
        public async Task<ActionResult> GetEmployeesWithFloor_TabularFormat()
        {
            var gotEmployees = await employeeService.GetEmployeesWithFloor_TabularFormat_Service();
            return Ok(gotEmployees);

        }


        [HttpGet]
        [Route("groupEmployeesByFloor")]
        public async Task<ActionResult> GroupEmployeesByFloor()
        {
            var gotGroupOfEmployees = await employeeService.GroupEmployeesByFloor_Service();
            return Ok(gotGroupOfEmployees);

        }
    }
}

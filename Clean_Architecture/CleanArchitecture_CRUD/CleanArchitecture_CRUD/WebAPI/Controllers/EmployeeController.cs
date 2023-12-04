using Application.DTOs.EmployeeDTOs;
using Application.EmployeeCQRS.Commands;
using Application.EmployeeCQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class EmployeeController : APIControllerBase
    {

        [HttpGet]
        [Route("GetAllEmployeesAsync")]
        public async Task<ActionResult> GetAllEmployeesAsync()
        {
            var gotAllEmployees = await Mediator.Send(new GetAllEmployeesQuery());
            return Ok(gotAllEmployees);
        }


        [HttpGet]
        [Route("GetEmployeeByID")]
        public async Task<ActionResult> GetEmployeeByIDAsync(int _empID)
        {
            var gotEmployee = await Mediator.Send(new GetEmployeeByIDQuery {EmpID = _empID});
            return Ok(gotEmployee);
        }


        [HttpPost]
        [Route("AddEmployee")]
        public async Task<ActionResult> AddEmployee([FromBody] AddEmployeeDTO _addEmployeeDTO)
        {
            var gotEmployee = await Mediator.Send(new AddEmployeeCommand { addEmployeeDTO = _addEmployeeDTO });
            return Ok(gotEmployee);
        }


        [HttpPatch]
        [Route("UpdateEmployeeName")]
        public async Task<ActionResult> UpdateEmployeeName(int _empID, string _empName)
        {
            var gotUpdatedEmployee = await Mediator.Send(
                new UpdateEmployeeNameCommand {  empID = _empID, newEmpName = _empName }
                );
            return Ok(gotUpdatedEmployee);
        }


        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<ActionResult> DeleteEmployee(int _empID)
        {
            var gotMessage = await Mediator.Send(new DeleteEmployeeCommand {  EmpID = _empID });
            return Ok(gotMessage);
        }

    }
}

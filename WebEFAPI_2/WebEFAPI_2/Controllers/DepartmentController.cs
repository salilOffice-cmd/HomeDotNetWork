using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using WebEFAPI_2.Contexts;
using WebEFAPI_2.Models;

namespace WebEFAPI_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Employee>))]
        public ActionResult GetAllDepartments()
        {
            using (CompanyDBContext context = new CompanyDBContext())
            {
                var DepartmentTable = context.Departments.ToList();
                return Ok(DepartmentTable);
            }
        }



        // Understanding Model Binding


        // not using model binding
        [HttpPost]
        [Route("AddDept")]
        public ActionResult AddDepartment1(string deptName, string deptTechnology)
        {

            using (CompanyDBContext context = new CompanyDBContext())
            {

                Department newDept = new Department
                {
                    Dept_Name = deptName,
                    Dept_Technology = deptTechnology
                };

                context.Departments.Add(newDept);
                context.SaveChanges();
                return Ok("Department Added");
            }
        }


        // model binding from body
        [HttpPost]
        [Route("AddDept1")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(SerializableError))]
        // The[FromBody] attribute is used to specify that the
        // employee parameter should be bound from the request body.
        // This means that the data for the employee parameter is expected to be sent
        // in the HTTP request's body, typically in a format such as JSON or XML.
        // The model binder will take care of deserializing the request body data into the Employee object.
        public ActionResult AddDepartment1([FromBody] Department dept)
        {
            // Giving custom validations

            // 1. Directly adding error message to modelstate(below)
            // Use [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(SerializableError))]
            //if(dept.Dept_Name.Length > 15)
            //{
            //    ModelState.AddModelError("Dept Length Error", "Department name length must be less than 15 letters");
            //    return BadRequest(ModelState);
            //}

            // 2. Using custom attribute (see ./Validations/DeptNameCheckAttribute.cs)


            using (CompanyDBContext context = new CompanyDBContext())
            {
                Department newDept = new Department
                {
                    Dept_Name = dept.Dept_Name,
                    Dept_Technology = dept.Dept_Technology,
                };

                context.Departments.Add(newDept);
                context.SaveChanges();
                return Ok("Department Added");
            }
        }



        // model binding from query 
        // https://localhost:5269/api/Department/AddDept2?deptName=IT&deptTechnology=Bigdata
        [HttpGet]
        [Route("AddDept2")]
        public ActionResult AddDepartment2([FromQuery]string deptName, [FromQuery]string deptTechnology)
        {
            // Data annotations dont work when using query binding
            // If you want to apply validation to query parameters,
            // you'll need to perform the validation explicitly in your action method
            if (deptTechnology.Length > 10)
            {
                ModelState.AddModelError("Check_deptTech", "Tech should be less than 10 chars");
                return BadRequest(ModelState);
            }

            if(deptName.Length > 15)
            {
                ModelState.AddModelError("Check_deptName", "Dept Name should be less than 15 chars");
                return BadRequest(ModelState);
            }

            using (CompanyDBContext context = new CompanyDBContext())
            {

                Department newDept = new Department
                {
                    Dept_Name = deptName,
                    Dept_Technology = deptTechnology
                };

                context.Departments.Add(newDept);
                context.SaveChanges();
                return Ok("Department Added");
            }
        }


        // model binding from route
        [HttpGet]
        [Route("AddDept3/{deptName}/{deptTechnology}")]
        public ActionResult AddDepartment3([FromRoute] string deptName, [FromRoute] string deptTechnology)
        {
            // Validations same as query Binding
            // Data annotations dont work when using route binding
            // If you want to apply validation to route parameters,
            // you'll need to perform the validation explicitly in your action method
            if (deptTechnology.Length > 10)
            {
                ModelState.AddModelError("Check_deptTech", "Tech should be less than 10 chars");
                return BadRequest(ModelState);
            }

            if (deptName.Length > 15)
            {
                ModelState.AddModelError("Check_deptName", "Dept Name should be less than 15 chars");
                return BadRequest(ModelState);
            }

            using (CompanyDBContext context = new CompanyDBContext())
            {

                Department newDept = new Department
                {
                    Dept_Name = deptName,
                    Dept_Technology = deptTechnology
                };

                context.Departments.Add(newDept);
                context.SaveChanges();
                return Ok("Department Added");
            }
        }


    }
}

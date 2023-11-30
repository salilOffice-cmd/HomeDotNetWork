using Application.CoursesCQRS.Commands;
using Application.CoursesCQRS.Queries;
using Application.DTOs.CourseDTOs;
using Application.StudentsCQRS.Queries;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CourseController : APIControllerBase
    {
        private readonly IValidator<AddCourseDTO> addCourseValidator;
        public CourseController(IValidator<AddCourseDTO> _addCourseValidator)
        { 
            addCourseValidator = _addCourseValidator;
        }

        //public ActionResult validateRoute(IValidationContext obj, IValidator validator)
        //{
        //    var validationResult = validator.Validate(obj);
        //    if (!validationResult.IsValid)
        //    {
        //        var errors = validationResult.Errors.Select(e => e.ErrorMessage);
        //        return BadRequest(new { errors });
        //    }
        //}


        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddCourseAsync([FromBody] AddCourseDTO _addCourseDTO)
        {
            var validationResult = addCourseValidator.Validate(_addCourseDTO);
            if(!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                return BadRequest(new { errors });
            }    


            var addCourseCommand = new AddCourseCommand { addCourseDTO = _addCourseDTO};
            var gotAddedCourse = await Mediator.Send(addCourseCommand);
            return Ok(gotAddedCourse);
        }


        [HttpGet]
        [Route("get/{courseID}")]
        public async Task<ActionResult> GetCourseByIDAsync(int courseID)
        {
            var gotCourse = await Mediator.Send(new GetCourseByIDQuery{ CourseID =  courseID });
            return Ok(gotCourse);
        }


        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult> GetAllCoursesAsync()
        {
            var gotAllCourses = await Mediator.Send(new GetAllCoursesQuery { });
            return Ok(gotAllCourses);
        }


        [HttpDelete]
        [Route("delete/{courseID}")]
        public async Task<ActionResult> DeleteCourseByIDAsync(int courseID)
        {
            var gotMessage = await Mediator.Send(new DeleteCourseCommand { CourseID = courseID });
            return Ok(gotMessage);
        }


        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateCourse([FromBody] UpdateCourseDTO _updateCourseDTO)
        {
            var gotMessage = await Mediator.Send(new UpdateCourseCommand { UpdateCourseDTO = _updateCourseDTO });
            return Ok(gotMessage);
        }
    }
}

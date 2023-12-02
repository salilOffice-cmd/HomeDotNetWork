﻿using Application.CoursesCQRS.Commands;
using Application.CoursesCQRS.Queries;
using Application.DTOs.CourseDTOs;
using Application.DTOs.StudentDTOs;
using Application.StudentsCQRS.Commands;
using Application.StudentsCQRS.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class StudentController : APIControllerBase
    {

        [HttpGet]
        [Route("students/{studentID}")]
        public async Task<ActionResult> GetStudentByIDAsync(int studentID)
        {
            var gotStudent = await Mediator.Send(new GetStudentByIDQuery { studentID = studentID });
            return Ok(gotStudent);
        }


        [HttpGet]
        [Route("students")]
        public async Task<ActionResult> GetAllStudentsAsync()
        {
            var gotAllStudents = await Mediator.Send(new GetAllStudentsQuery { });
            return Ok(gotAllStudents);
        }


        [HttpPost]
        [Route("students")]
        public async Task<ActionResult> AddStudentAsync([FromBody] AddStudentDTO _addStudentDTO)
        {
            var addStudentCommand = new AddStudentCommand { addStudentDTO = _addStudentDTO };
            var gotAddedStudent = await Mediator.Send(addStudentCommand);
            return Ok(gotAddedStudent);
        }


        [HttpDelete]
        [Route("students/{studentID}")]
        public async Task<ActionResult> DeleteStudentByIDAsync(int studentID)
        {
            var gotMessage = await Mediator.Send(new DeleteStudentCommand { StudentID = studentID });
            return Ok(gotMessage);
        }

        [HttpPut]
        [Route("students/{studentID}")]
        public async Task<ActionResult> UpdateStudent(int studentID, [FromBody] UpdateStudentDTO _updateStudentDTO)
        {
            var gotMessage = await Mediator.Send(new UpdateStudentCommand { 
                                            studentId = studentID,
                                            UpdateStudentDTO = _updateStudentDTO
                                           });
            return Ok(gotMessage);
        }
    }
}

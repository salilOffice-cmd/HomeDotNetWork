using Application.DTOs.CourseDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class CourseValidator : AbstractValidator<AddCourseDTO>
    {
        public CourseValidator()
        {
            RuleFor(c => c.CourseName)
                .NotEmpty().WithMessage("Coursename should not be empty or null")
                .Length(3, 50).WithMessage("Coursename must be 3 to 50 characters long");

        }

    }
}

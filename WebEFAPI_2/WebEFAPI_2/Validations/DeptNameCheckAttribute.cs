﻿using System.ComponentModel.DataAnnotations;

namespace WebEFAPI_2.Validations
{
    public class DeptNameCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? dept_name = (string?) value;

            if(dept_name.Length > 15)
            {
                return new ValidationResult("Custom Attribute -> Department name length must be less than 15 letters");
            }

            return ValidationResult.Success;
        }

        // Note - 
        // After creating this custom attribute, we can use it like data annotations

        // Note 2 -
        //  custom validation attributes are primarily used for data validation
        //  and do not affect the database schema generated by Entity Framework Core.
        //  These custom validation attributes are used to validate data at the
        //  application level before it is stored in the database.
        //  They provide a mechanism to enforce specific validation rules on your data model.
    }
}

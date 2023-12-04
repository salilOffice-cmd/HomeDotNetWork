using Application.DTOs.EmployeeDTOs;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.EmployeeCQRS.Commands
{
    public class AddEmployeeCommand : IRequest<Employee>
    {
        public AddEmployeeDTO addEmployeeDTO { get; set; }
    }


    public class AddEmployeeCommand_Handler : IRequestHandler<AddEmployeeCommand, Employee>
    {
        private readonly IApplicationDBContext context;
        public AddEmployeeCommand_Handler(IApplicationDBContext _applicationDBContext)
        {
            context = _applicationDBContext;
        }

        public async Task<Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {

            Employee newEmployee = new Employee
            {
                EmployeeName = request.addEmployeeDTO.EmployeeName,
                EmployeeAge = request.addEmployeeDTO.EmployeeAge,
            };


            context.Employees.Add(newEmployee);
            await context.SaveChangesAsync(cancellationToken);

            return newEmployee;

        }
    }
}

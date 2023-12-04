using Application.DTOs.DepartmentDTOs;
using Application.EmployeeCQRS.Commands;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DepartmentCQRS.Commands
{
    public class AddDepartmentCommand : IRequest<department>
    {
        public AddDepartmentDTO addDepartmentDto {  get; set; }
    }

    public class AddDepartmentCommand_Handler : IRequestHandler<AddDepartmentCommand, department>
    {
        private readonly IApplicationDBContext context;
        public AddDepartmentCommand_Handler(IApplicationDBContext _applicationDBContext)
        {
            context = _applicationDBContext;
        }

        public async Task<department> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            department newDepartment = new department()
            {
                department_name = request.addDepartmentDto.department_name
            };

            context.Departments.Add(newDepartment);
            await context.SaveChangesAsync(cancellationToken);

            return newDepartment;
        }
    }
}

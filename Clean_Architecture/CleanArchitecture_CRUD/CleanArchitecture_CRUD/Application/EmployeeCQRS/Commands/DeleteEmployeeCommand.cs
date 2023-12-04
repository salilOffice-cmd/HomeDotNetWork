using Application.DTOs.EmployeeDTOs;
using Application.EmployeeCQRS.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeCQRS.Commands
{
    public class DeleteEmployeeCommand : IRequest<string>
    {
        public int EmpID { get; set; }
    }


    public class DeleteEmployeeCommand_Handler : IRequestHandler<DeleteEmployeeCommand, string>
    {
        private readonly IApplicationDBContext context;
        private readonly IMediator mediator;

        public DeleteEmployeeCommand_Handler(IApplicationDBContext _applicationDBContext,
                                             IMediator _mediator)
        {
            context = _applicationDBContext;
            mediator = _mediator;
        }

        public async Task<string> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            //var gotEmployeeTable = await context.Employees.ToListAsync();

            //var gotEmployee = gotEmployeeTable
            //                .FirstOrDefault(emp => emp.EmployeeID == request.EmpID);

            // OR

            // Call existing class that returns the employee by ID
            var gotEmployee2 = await mediator.Send(new GetEmployeeByIDQuery { EmpID = request.EmpID });

            context.Employees.Remove(gotEmployee2);
            await context.SaveChangesAsync(cancellationToken);

            return "Employee Deleted";
        }
    }
}

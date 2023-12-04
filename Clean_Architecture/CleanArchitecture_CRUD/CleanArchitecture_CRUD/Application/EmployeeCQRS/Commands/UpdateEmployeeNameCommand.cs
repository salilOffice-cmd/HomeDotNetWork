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
    public class UpdateEmployeeNameCommand : IRequest<Employee>
    {
        public int empID { get; set; }
        public string newEmpName { get; set; }
    }


    public class UpdateEmployeeNameCommand_Handler : IRequestHandler<UpdateEmployeeNameCommand, Employee>
    {
        private readonly IApplicationDBContext context;
        public UpdateEmployeeNameCommand_Handler(IApplicationDBContext _applicationDBContext)
        {
            context = _applicationDBContext;
        }

        public async Task<Employee> Handle(UpdateEmployeeNameCommand request, CancellationToken cancellationToken)
        {
            var gotEmployeeTable = await context.Employees.ToListAsync();

            var gotEmployee = gotEmployeeTable
                            .FirstOrDefault(emp => emp.EmployeeID == request.empID);

            gotEmployee.EmployeeName = request.newEmpName;
            await context.SaveChangesAsync(cancellationToken);

            return gotEmployee;
        }
    }
}

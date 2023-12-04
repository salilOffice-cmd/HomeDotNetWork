using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeCQRS.Queries
{
    public class GetEmployeeByIDQuery : IRequest<Employee>
    {
        public int EmpID { get; set; }
    }


    public class GetEmployeeByIDQuery_Handler : IRequestHandler<GetEmployeeByIDQuery, Employee>
    {
        private readonly IApplicationDBContext context;
        public GetEmployeeByIDQuery_Handler(IApplicationDBContext _applicationDBContext)
        {
            context = _applicationDBContext;
        }

        public async Task<Employee> Handle(GetEmployeeByIDQuery request, CancellationToken cancellationToken)
        {
            var gotAllEmployees = await context.Employees.ToListAsync();

            var gotEmployee = gotAllEmployees.FirstOrDefault(emp => emp.EmployeeID == request.EmpID);
            return gotEmployee;
        }
    }
}

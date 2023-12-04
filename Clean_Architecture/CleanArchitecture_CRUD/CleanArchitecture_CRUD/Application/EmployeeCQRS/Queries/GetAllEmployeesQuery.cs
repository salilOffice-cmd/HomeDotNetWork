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
    public class GetAllEmployeesQuery : IRequest<List<Employee>>
    {
        
    }

    public class GetAllEmployeesQuery_Handler : IRequestHandler<GetAllEmployeesQuery, List<Employee>>
    {
        private readonly IApplicationDBContext context;
        public GetAllEmployeesQuery_Handler(IApplicationDBContext _applicationDBContext)
        {
            context = _applicationDBContext;
        }

        public async Task<List<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var gotAllEmployees = await context.Employees.ToListAsync();
            return gotAllEmployees;
        }
    }
}

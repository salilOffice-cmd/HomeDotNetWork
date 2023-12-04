using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DepartmentCQRS.Queries
{
    public class GetAllDepartments : IRequest<List<department>>
    {

    }


    public class GetAllDepartments_Handler : IRequestHandler<GetAllDepartments, List<department>>
    {

        private readonly IApplicationDBContext context;
        public GetAllDepartments_Handler(IApplicationDBContext _applicationDBContext)
        {
            context = _applicationDBContext;
        }

        public async Task<List<department>> Handle(GetAllDepartments request, CancellationToken cancellationToken)
        {
            var gotDepartmentTable = await context.Departments.ToListAsync();
            return gotDepartmentTable;
        }
    }
}

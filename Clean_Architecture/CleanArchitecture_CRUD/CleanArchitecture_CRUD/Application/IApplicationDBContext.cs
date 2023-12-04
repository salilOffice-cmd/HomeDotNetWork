using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public interface IApplicationDBContext
    {
        DbSet<Employee> Employees { get; }

        DbSet<department> Departments { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

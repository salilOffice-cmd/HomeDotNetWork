using Microsoft.EntityFrameworkCore;
using WebEFAPI_2.Models;

namespace WebEFAPI_2.Contexts
{
    public class CompanyDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"
            //Server=LAPTOP-TG7EDFJP\SQLEXPRESS;
            //Database=CompanyDBContext;
            //Trusted_Connection=true;
            //TrustServerCertificate=true;
            //MultipleActiveResultSets=true;
            //");

            optionsBuilder.UseSqlServer(@"
            Server=DESKTOP-O0RHDOB\SQLEXPRESS2021;
            Database=CompanyDBContext;
            Trusted_Connection=true;
            TrustServerCertificate=true;
            MultipleActiveResultSets=true;
            ");
        }

    }
}

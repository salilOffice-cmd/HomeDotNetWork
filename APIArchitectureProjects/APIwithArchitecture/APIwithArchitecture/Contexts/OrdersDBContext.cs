using APIwithArchitecture.Models;
using Microsoft.EntityFrameworkCore;

namespace APIwithArchitecture.Contexts
{
    public class OrdersDBContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
            Server=LAPTOP-TG7EDFJP\SQLEXPRESS;
            Database=OrdersDB;
            Trusted_Connection=true;
            TrustServerCertificate=true;
            MultipleActiveResultSets=true;
            ");
        }
    }
}

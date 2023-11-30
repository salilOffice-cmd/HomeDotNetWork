using APIwithArchitecture.Models;
using Microsoft.EntityFrameworkCore;

namespace APIwithArchitecture.Contexts
{
    public class OrdersDBContext : DbContext
    {

        public OrdersDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
    }
}

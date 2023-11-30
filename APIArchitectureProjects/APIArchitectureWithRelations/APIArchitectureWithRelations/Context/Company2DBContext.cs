using APIArchitectureWithRelations.Models;
using Microsoft.EntityFrameworkCore;

namespace APIArchitectureWithRelations.Context
{
    public class Company2DBContext : DbContext
    {
        public Company2DBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Floor> Floors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SystemDetail> SystemDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Floor>(builder =>
            {
                // FloorId
                builder.HasKey(f => f.FloorId);

                builder.Property(f => f.FloorId)
                       .ValueGeneratedOnAdd()
                       .UseIdentityColumn(1, 1);



                // FloorName
                builder.HasIndex(f => f.FloorName)
                       .IsUnique();


                builder.Property(f => f.FloorName)
                       .HasMaxLength(50)
                       .IsRequired();


                // Relationship
                builder.HasMany(f => f.Employees)
                       .WithOne(e => e.Floor)
                       .HasForeignKey(e => e.Floor_Id);

            });


            modelBuilder.Entity<Employee>(builder =>
            {
                builder.HasKey(emp => emp.EmployeeId);

                builder.Property(f => f.EmployeeId)
                       .ValueGeneratedOnAdd()
                       .UseIdentityColumn(1, 1);



                // Relationship 
                builder.HasOne(emp => emp.SystemDetail)
                       .WithOne(sys => sys.Employee)
                       .HasForeignKey<SystemDetail>(sys => sys.Emp_Id);


            });


            modelBuilder.Entity<SystemDetail>(builder =>
            {
                builder.HasKey(sys => sys.SystemDetailId);

                builder.Property(sys => sys.SystemDetailId)
                       .ValueGeneratedOnAdd()
                       .UseIdentityColumn(1, 1);
            });

        }


    }
}

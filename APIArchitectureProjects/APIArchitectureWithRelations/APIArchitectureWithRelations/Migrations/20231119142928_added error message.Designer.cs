﻿// <auto-generated />
using APIArchitectureWithRelations.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIArchitectureWithRelations.Migrations
{
    [DbContext(typeof(Company2DBContext))]
    [Migration("20231119142928_added error message")]
    partial class addederrormessage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIArchitectureWithRelations.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int>("Floor_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tech")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("Floor_Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("APIArchitectureWithRelations.Models.Floor", b =>
                {
                    b.Property<int>("FloorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FloorId"));

                    b.Property<string>("FloorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FloorId");

                    b.HasIndex("FloorName")
                        .IsUnique()
                        .HasAnnotation("UniqueViolation", "FloorName Must Be Unique");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("APIArchitectureWithRelations.Models.SystemDetail", b =>
                {
                    b.Property<int>("SystemDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SystemDetailId"));

                    b.Property<string>("ComputerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Emp_Id")
                        .HasColumnType("int");

                    b.HasKey("SystemDetailId");

                    b.HasIndex("Emp_Id")
                        .IsUnique();

                    b.ToTable("SystemDetails");
                });

            modelBuilder.Entity("APIArchitectureWithRelations.Models.Employee", b =>
                {
                    b.HasOne("APIArchitectureWithRelations.Models.Floor", "Floor")
                        .WithMany("Employees")
                        .HasForeignKey("Floor_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Floor");
                });

            modelBuilder.Entity("APIArchitectureWithRelations.Models.SystemDetail", b =>
                {
                    b.HasOne("APIArchitectureWithRelations.Models.Employee", "Employee")
                        .WithOne("SystemDetail")
                        .HasForeignKey("APIArchitectureWithRelations.Models.SystemDetail", "Emp_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("APIArchitectureWithRelations.Models.Employee", b =>
                {
                    b.Navigation("SystemDetail")
                        .IsRequired();
                });

            modelBuilder.Entity("APIArchitectureWithRelations.Models.Floor", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
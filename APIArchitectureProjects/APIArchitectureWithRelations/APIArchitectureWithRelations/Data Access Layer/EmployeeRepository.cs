using APIArchitectureWithRelations.Context;
using APIArchitectureWithRelations.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace APIArchitectureWithRelations.Data_Access_Layer
{
    public class EmployeeRepository : IEmployeeRepo
    {
        private readonly Company2DBContext context;
        public EmployeeRepository(Company2DBContext _context)
        { 
            context = _context;   
        }

        public async Task<List<Employee>> GetAllEmployees_Repo()
        {
            var employeeList = await context.Employees.ToListAsync();
            return employeeList;
        }

        public async Task<Employee> GetEmployeeByID_Repo(int empID)
        {
            var gotEmployee = await context.Employees
                                    .FirstOrDefaultAsync(emp => emp.EmployeeId == empID);
            return gotEmployee;
        }


        public async Task<Employee> AddEmployee_Repo(Employee employee)
        {
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return employee;
        }


        public async Task<List<Employee>> GetEmployeesWithFloor_Repo()
        {
            var allEmployees = await context.Employees.Include(emp => emp.Floor)
                                                      .ToListAsync();

            return allEmployees;
        }
            


    }
}

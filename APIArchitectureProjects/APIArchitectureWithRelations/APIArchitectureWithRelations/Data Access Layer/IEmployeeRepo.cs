using APIArchitectureWithRelations.Models;

namespace APIArchitectureWithRelations.Data_Access_Layer
{
    public interface IEmployeeRepo
    {
        Task<List<Employee>> GetAllEmployees_Repo();
        Task<Employee> GetEmployeeByID_Repo(int empID);
        Task<Employee> AddEmployee_Repo(Employee employee);
        Task<List<Employee>> GetEmployeesWithFloor_Repo();
    }
}

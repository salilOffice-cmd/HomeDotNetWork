using APIArchitectureWithRelations.DTOs;
using APIArchitectureWithRelations.Models;

namespace APIArchitectureWithRelations.Service_Layer
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeByID_Service(int empID);
        Task<Employee> AddEmployee_Service(AddEmployeeDTO addEmployeeDTO);
        Task<List<JoinEmployeesWithFloorDTO>> GetEmployeesWithFloor_Service();
        Task<List<string>> GetEmployeesWithFloor_TabularFormat_Service();

        Task<List<GroupEmployeesByFloorDTO>> GroupEmployeesByFloor_Service();
    }
}

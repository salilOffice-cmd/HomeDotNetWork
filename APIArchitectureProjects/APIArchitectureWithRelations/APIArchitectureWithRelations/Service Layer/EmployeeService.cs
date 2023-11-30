using APIArchitectureWithRelations.Data_Access_Layer;
using APIArchitectureWithRelations.DTOs;
using APIArchitectureWithRelations.Models;

namespace APIArchitectureWithRelations.Service_Layer
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo employeeRepo;
        public EmployeeService(IEmployeeRepo _employeeRepo)
        { 
            employeeRepo = _employeeRepo;
        }


        public async Task<Employee> GetEmployeeByID_Service(int empID)
        {
            var gotEmployee = await employeeRepo.GetEmployeeByID_Repo(empID);
            return gotEmployee;
        }



        public async Task<Employee> AddEmployee_Service(AddEmployeeDTO addEmployeeDTO)
        {
            //throw new Exception("Exception from EmployeeService");
            Employee newEmp = new Employee
            {
                Name = addEmployeeDTO.Name,
                Tech = addEmployeeDTO.Tech,
                Floor_Id = addEmployeeDTO.Floor_Id
            };

            //await employeeRepo.AddEmployee_Repo(newEmp);

            //var getAllEmployees = await employeeRepo.GetAllEmployees_Repo();
            //var getAddedEmployee = getAllEmployees.LastOrDefault();
            //return getAddedEmployee.EmployeeId;
            Employee gotAddedEmp = await employeeRepo.AddEmployee_Repo(newEmp);
            return gotAddedEmp;

        }


        public async Task<List<JoinEmployeesWithFloorDTO>> GetEmployeesWithFloor_Service()
        {
            var gotEmployees = await employeeRepo.GetEmployeesWithFloor_Repo();

            var gotEmployeesToDTO = gotEmployees.Select(emp => new JoinEmployeesWithFloorDTO
                                    {
                                        EmployeeId = emp.EmployeeId,
                                        Name = emp.Name,
                                        Tech = emp.Tech,
                                        Floor_Id = emp.Floor.FloorId,
                                        FloorName = emp.Floor.FloorName

                                    }).ToList();


            return gotEmployeesToDTO;
        }

        public async Task<List<string>> GetEmployeesWithFloor_TabularFormat_Service()
        {
            var gotEmployees = await employeeRepo.GetEmployeesWithFloor_Repo();

            var gotEmployeesToDTO = gotEmployees.Select(emp => new JoinEmployeesWithFloorDTO
            {
                EmployeeId = emp.EmployeeId,
                Name = emp.Name,
                Tech = emp.Tech,
                Floor_Id = emp.Floor.FloorId,
                FloorName = emp.Floor.FloorName

            }).ToList();

            List<string> dtoToStringList = new List<string>();

            foreach (var emp in gotEmployeesToDTO)
            {
                string empToString = emp.ObjectToString();
                dtoToStringList.Add(empToString);
            }


            return dtoToStringList;
        }

        public async Task<List<GroupEmployeesByFloorDTO>> GroupEmployeesByFloor_Service()
        {
            var allEmployees = await employeeRepo.GetAllEmployees_Repo();

            /*
             * Naggpur : [Emp1, Emp2]
             * MIhan : []
             */

            //List<Floor> allFloors = new List<Floor>();
            //var something = allFloors.Select(floor => floor.FloorName).ToList();


            var groupedEmployees = allEmployees.GroupBy(emp => emp.Floor_Id)
                        .Select(empGroup => new GroupEmployeesByFloorDTO
                        {
                            FloorID = empGroup.Key,
                            Employees = empGroup.Select(emp => new ShowEmployeeDTO
                            {
                                EmployeeId = emp.EmployeeId,
                                Name = emp.Name,
                                Tech = emp.Tech

                            }).ToList()

                        }).ToList();

            return groupedEmployees;
        }


    }
}

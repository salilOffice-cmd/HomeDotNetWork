using APIArchitectureWithRelations.Data_Access_Layer;
using APIArchitectureWithRelations.DTOs;
using APIArchitectureWithRelations.Models;

namespace APIArchitectureWithRelations.Service_Layer
{
    public class FloorService : IFloorService
    {
        private readonly IFloorRepo floorRepo;
        public FloorService(IFloorRepo _floorRepo)
        {
            floorRepo = _floorRepo;
        }


        public async Task AddFloor_Service(AddFloorDTO addFloorDTO)
        {
            Floor newFloor = new Floor
            {
                FloorName = addFloorDTO.FloorName,
            };

            await floorRepo.AddFloor_Repo(newFloor);

        }

        public async Task<JoinFloorSpecificEmployeesDTO> GetFloorSpecificEmployees_Service(int _floorID)
        {
            var getFloorSpecificEmployees = await floorRepo.GetFloorSpecificEmployees_Repo(_floorID);

            JoinFloorSpecificEmployeesDTO joinFloorSpecificEmployees = new JoinFloorSpecificEmployeesDTO
            {
                Floor_Id = getFloorSpecificEmployees.FloorId,
                FloorName = getFloorSpecificEmployees.FloorName,
                Employees = getFloorSpecificEmployees.Employees.Select(emp => new ShowEmployeeDTO
                {
                    EmployeeId = emp.EmployeeId,
                    Name = emp.Name,
                    Tech = emp.Tech

                }).ToList()
            };

            return joinFloorSpecificEmployees;
        }


    }
}

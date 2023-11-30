using APIArchitectureWithRelations.DTOs;

namespace APIArchitectureWithRelations.Service_Layer
{
    public interface IFloorService
    {
        Task AddFloor_Service(AddFloorDTO addFloorDTO);
        Task<JoinFloorSpecificEmployeesDTO> GetFloorSpecificEmployees_Service(int _floorID);
    }
}

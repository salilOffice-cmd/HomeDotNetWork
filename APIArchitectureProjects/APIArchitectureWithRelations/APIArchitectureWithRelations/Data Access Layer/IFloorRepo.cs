using APIArchitectureWithRelations.Models;

namespace APIArchitectureWithRelations.Data_Access_Layer
{
    public interface IFloorRepo
    {
        Task AddFloor_Repo(Floor floor);
        Task<Floor> GetFloorSpecificEmployees_Repo(int floorId);
    }
}

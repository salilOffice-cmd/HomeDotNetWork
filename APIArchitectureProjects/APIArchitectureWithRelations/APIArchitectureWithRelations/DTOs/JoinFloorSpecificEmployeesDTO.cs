using APIArchitectureWithRelations.Models;

namespace APIArchitectureWithRelations.DTOs
{
    public class JoinFloorSpecificEmployeesDTO
    {

        public int Floor_Id { get; set; }

        public string FloorName { get; set; }

        public List<ShowEmployeeDTO> Employees { get; set; }
    }
}

using APIArchitectureWithRelations.Models;

namespace APIArchitectureWithRelations.DTOs
{
    public class AddEmployeeDTO
    {
        public string Name { get; set; }
        public string Tech { get; set; }
        public int Floor_Id { get; set; }

    }
}

using APIArchitectureWithRelations.Models;

namespace APIArchitectureWithRelations.DTOs
{
    public class JoinEmployeesWithFloorDTO
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Tech { get; set; }

        public int Floor_Id { get; set; }
        public string FloorName { get; set; }

        public string ObjectToString()
        {
            string concatObject = $"{EmployeeId} | {Name} | {Tech} | " +
                $"{Floor_Id} | {FloorName} ";
            return concatObject;
        }

    }
}

namespace APIArchitectureWithRelations.Models
{

    public class Floor
    {
        public int FloorId { get; set; }
        public string FloorName { get; set; }


        // Navigation property: One-to-Many relationship with Employees
        public List<Employee> Employees { get; set; }
    }

}

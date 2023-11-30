namespace APIArchitectureWithRelations.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Tech { get; set; }


        // Navigation property: Many-to-One relationship with Floors
        public int Floor_Id { get; set; }
        public Floor Floor { get; set; }


        // Navigation property: One-to-One relationship with SystemDetails
        public SystemDetail SystemDetail { get; set; }
    }

}

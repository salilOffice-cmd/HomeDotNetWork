namespace APIArchitectureWithRelations.Models
{
    public class SystemDetail
    {
        public int SystemDetailId { get; set; }
        public string ComputerName { get; set; }


        // Navigation property: One-to-One relationship with Employee
        public int Emp_Id { get; set; }
        public Employee Employee { get; set; }
    }

}

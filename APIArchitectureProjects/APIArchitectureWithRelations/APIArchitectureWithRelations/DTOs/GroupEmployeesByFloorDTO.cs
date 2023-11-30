namespace APIArchitectureWithRelations.DTOs
{
    public class GroupEmployeesByFloorDTO
    {
        public int FloorID { get; set; }
        //public string FloorName { get; set; }

        public List<ShowEmployeeDTO> Employees { get; set; }
    }
}

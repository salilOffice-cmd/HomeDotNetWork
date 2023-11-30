using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APIArchitectureWithRelations.DTOs
{
    public class AddFloorDTO
    {
        // [Required(ErrorMessage = "FloorName is required!!")]
        public string FloorName { get; set; }
    }
}

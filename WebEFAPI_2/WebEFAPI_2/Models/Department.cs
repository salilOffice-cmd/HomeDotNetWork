using System.ComponentModel.DataAnnotations;
using WebEFAPI_2.Validations;

namespace WebEFAPI_2.Models
{
    public class Department
    {
        [Key]
        public int Dept_Id { get; set; }

        [DeptNameCheck]
        public string Dept_Name { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Tech should be less than 10 chars")]
        public string Dept_Technology { get; set; }
    }
}

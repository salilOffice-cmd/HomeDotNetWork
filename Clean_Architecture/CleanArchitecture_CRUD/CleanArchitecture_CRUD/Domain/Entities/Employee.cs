using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee : Auditable
    {
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
    }
}

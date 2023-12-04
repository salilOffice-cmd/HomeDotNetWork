using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class department : Auditable
    {
        public int id { get; set; }

        public string department_name { get; set; }
    }
}

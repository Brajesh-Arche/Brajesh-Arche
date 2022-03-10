using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arche.Domain
{
    public class Employee:BaseEntity
    {
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Designation { get; set; }
        public decimal Salary { get; set; }
    }
}

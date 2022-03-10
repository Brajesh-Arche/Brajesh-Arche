using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arche.Domain
{
    public class EmployeeMap
    {
        public EmployeeMap(EntityTypeBuilder<Employee> Emp)
        {
            Emp.HasKey(e => e.Id);
            Emp.Property(e => e.EmployeeName);
            Emp.Property(e => e.Email);
            Emp.Property(e => e.Gender);
            Emp.Property(e => e.Designation);
            Emp.Property(e => e.Salary);
        }
    }
}

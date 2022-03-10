using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Mvc;

namespace ArcheProject.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Display(Name ="Employee Name")]
        [Required (ErrorMessage ="Please Enter Employee Name")]
        public string EmployeeName { get; set; }
        public string gender { get; set; }
        [Required (ErrorMessage ="Please Enter Email Id")]
        public string Email { get; set; }
        public string Designation { get; set; }
        public decimal Salary { get; set; }
    }
}

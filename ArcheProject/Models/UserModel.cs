using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Mvc;
namespace ArcheProject.Models
{
    public class UserModel
    {
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

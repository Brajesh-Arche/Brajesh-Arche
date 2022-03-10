using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Arche.Domain
{
    public class UserLogin:BaseEntity
    {
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Display(Name ="Password")]
        public string UserPassword { get; set; }
    }
}

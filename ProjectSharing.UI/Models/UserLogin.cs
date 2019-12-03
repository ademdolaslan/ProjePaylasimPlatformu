using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSharing.UI.Models
{
    public class UserLogin
    {
        [Required]
        [Display(Name ="User Name" )]
        public string Username { get; set; }
        [Required]
        [Display(Name ="Password")]
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightHouseV1.Models
{
    public class AccountLoginViewModel
    {
        [Required, MaxLength(256), EmailAddress]
        [Display(Name = "Email Addres")]
        public string Email { get; set; }
        [Required, MinLength(6), MaxLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}

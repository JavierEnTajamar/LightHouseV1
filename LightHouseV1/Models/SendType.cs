using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightHouse.Models
{
    public class SendType
    {
        [Key]
        public int SendTypeId { get; set; }
        [Display(Name = "Send Type")]
        public string SendTypeName{ get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightHouseV1.Models
{
    public class ClaimedBy
    {
        [Key]
        public int ClaimedById { get; set; }
        [Display(Name = "Claimed By")]
        public string ClaimedByType { get; set; }

    }
}

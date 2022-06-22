using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightHouse.Models
{
    public class CastawayRoadType
    {
        [Key]
        public int CastawayRoadTypeId { get; set; }
        [Display(Name = "Road Type Name")]
        public string CastawayRoadTypeName { get; set; }
    }
}

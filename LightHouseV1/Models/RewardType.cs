using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightHouseV1.Models
{
    public class RewardType
    {
        [Key]
        public int RewardTypeId { get; set; }
        [Display(Name = "Reward")]
        public string RewardTypeName { get; set; }
    }
}

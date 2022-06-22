using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightHouseV1.Models
{
    public class RewardStatus
    {
        [Key]
        public int RewardStatusId { get; set; }
        [Display(Name = "Status")]
        public string RewardStatusType { get; set; }

    }
}

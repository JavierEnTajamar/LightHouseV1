using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightHouseV1.Models
{
    public class RewardComposition
    {
        [Key]
        public int RewardCompositionId { get; set; }
        [Display(Name = "Composition")]
        public string RewardComponents { get; set; }

    }
}

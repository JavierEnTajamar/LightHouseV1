using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightHouseV1.Models
{

    public class Reward
    {
        [Key]
        public int RewardId { get; set; }
        [Display(Name = "Reward Type Id")]
        public int RewardTypeId { get; set; }
        [Display(Name = "Reward Type")]
        public virtual RewardType RewardType { get; set; }
        [Display(Name = "Castaway Id")]
        public int CastawayId { get; set; }
        [Display(Name = "Castaway")]
        public virtual Castaway Castaway { get; set; }
        [Display(Name = "Claim Type Id")]
        public int ClaimedById { get; set; }
        [Display(Name = "Claim Type")]
        public virtual ClaimedBy ClaimedBy { get; set; }
        [Display(Name = "Claim Day")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ClaimDay { get; set; }
        [Display(Name = "Reward Color")]
        [RegularExpression("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "Invalid Format")]     
        public string RewardColor { get; set; }
        [Display(Name = "Spray Color")]
        [RegularExpression("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "Invalid Format")]
        public string RewardSprayColor { get; set; }
        [Display(Name = "Template Id")]
        public int TemplateId { get; set; }
        [Display(Name = "Template")]
        public virtual Template Template { get; set; }
        [Display(Name = "Buy Price")]
        public double BuyPrice { get; set; }
        [Display(Name = "Size")]
        public string Size { get; set; }
        [Display(Name = "Weight (grs)")]
        public int Weight { get; set; }
        [Display(Name = "Reward Composition Id Type")]
        public int RewardCompositionId { get; set; }
        [Display(Name = "Composition")]
        public virtual RewardComposition RewardComposition  { get; set; }
        [Display(Name = "Reward Status Id")]
        public int RewardStatusId { get; set; }
        [Display(Name = "Status")]
        public virtual RewardStatus RewardStatus  { get; set; }
    }
}

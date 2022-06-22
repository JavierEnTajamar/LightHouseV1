using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightHouseV1.Models
{
    public class SendContent
    {
        [Key]
        public int SendContentId { get; set; }
        [Display(Name = "Send")]
        public virtual Send Send { get; set; }
        [Display(Name = "Reward")]
        public virtual Reward Reward { get; set; }
    }
}

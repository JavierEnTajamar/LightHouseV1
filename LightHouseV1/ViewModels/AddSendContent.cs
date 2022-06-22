using LightHouseV1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightHouseV1.ViewModels
{
    public class AddSendContent
    {
        public SendContent SendContent { get; set; }
        public Send Send { get; set; }        
        public SelectList SendList { get; set; }
        public Reward Reward { get; set; }
        public SelectList RewardList { get; set; }

    }
}

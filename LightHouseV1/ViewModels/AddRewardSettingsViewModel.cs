using LightHouseV1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightHouseV1.ViewModels
{
    public class AddRewardSettingsViewModel
    {
        public Reward Reward { get; set; }
        public RewardType RewardType { get; set; }
        public SelectList RewardTypeList { get; set; }
        public Castaway Castaway { get; set; }
        public SelectList CastawayList { get; set; }
        public ClaimedBy ClaimedBy { get; set; }
        public SelectList ClaimedByList { get; set; }
        public Template Template { get; set; }
        public SelectList TemplateList { get; set; }
        public RewardComposition RewardComposition { get; set; }
        public SelectList RewardCompositionList { get; set; }
        public RewardStatus RewardStatus { get; set; }
        public SelectList RewardStatusList { get; set; }

    }
}

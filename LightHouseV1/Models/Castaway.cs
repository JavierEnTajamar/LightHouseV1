using LightHouseV1.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightHouseV1.Models
{
    public enum CastawayRoadType { Street, Avenue, Road, Path, Highway }

    public class Castaway
    {
        public int CastawayId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Display(Name = "Twitch Name")]
        public string CastawayTwitchName { get; set; }
        [Display(Name = "Name")]
        public string CastawayName { get; set; }
        [Display(Name = "Last Name")]
        public string CastawayLastName { get; set; }
        [Display(Name = "Second Last Name")]
        public string CastawaySecondLastName { get; set; }
        [Display(Name = "Telephone")]
        public string CastawayTelephone { get; set; }
        [Display(Name = "City Name")]
        public string CityName { get; set; }
        [Display(Name = "Postal Code")]
        public string CastawayPostalCode { get; set; }
        [Display(Name = "Road Type")]
        public CastawayRoadType CastawayRoadType { get; set; }
        [Display(Name = "Road Name")]
        public string CastawayRoadName { get; set; }
        [Display(Name = "Number")]
        public string CastawayHomeNumber { get; set; }
        [Display(Name = "Portal")]
        public string CastawayHomePortal { get; set; }
        [Display(Name = "Floor")]
        public string CastawayHomeFloor { get; set; }
        [Display(Name = "Home Door")]
        public string CastawayHomeDoor { get; set; }
        public int WolfCoins { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightHouseV1.Models
{
    public class Send
    {
        [Key]
        public int SendId { get; set; }
        [Display(Name = "Tracking Code")]
        public string TrackingCode { get; set; }
        [Display(Name = "Lightkeeper Code ")]
        public string SendName { get; set; }
        [Display(Name = "Type")]
        public SendType SendType { get; set; }
        [Display(Name = "Deliver")]
        public Deliver Deliver { get; set; }
        [Display(Name = "Price")]
        public double? SendPrice { get; set; }
        [Display(Name = "Send Day")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? SendDay { get; set; }
        [Display(Name = "Reception Day")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ReceptionDay { get; set; }
    }
    public enum SendType { National, Europe, International, OurPaws }
    public enum Deliver { CORREOS, UPS, MRW }

}

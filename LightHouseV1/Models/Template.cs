using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightHouseV1.Models
{
    public class Template
    {
        [Key]
        public int TemplateId { get; set; }
        [Display(Name = "Template")]
        public string TemplateName { get; set; }
    }
}

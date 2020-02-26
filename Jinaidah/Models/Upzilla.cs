using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jinaidah.Models
{
    public class Upzilla
    {
        public int Id { get; set; }
        [Display(Name ="District")]
        [Required]
        public int DistrictID { get; set; }
        [Display(Name = "Upzilla Name")]
        [Required]
        public string UpzillaName { get; set; }

        public District District { get; set; }

    }
}

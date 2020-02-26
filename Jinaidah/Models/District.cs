using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jinaidah.Models
{
    public class District
    {
        public int Id { get; set; }
        [Display(Name = "Division")]

        public int DivisionId { get; set; }
        [Display(Name = "District")]
        [Required]
        public string DistrictName { get; set; }

        public Division Division { get; set; }
        public ICollection<Upzilla> Upzilla { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jinaidah.Models
{
    public class Division
    {
        public int Id { get; set; }
        [Display(Name = "Division")]
        [Required]
        public string DivisonName { get; set; }


        public ICollection<District> Districts { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jinaidah.Models
{
    public class HoldingCategory
    {
        public int Id { get; set; }
        [Display(Name = "Holding category type")]
        [Required]
        public string TypeName { get; set;} //unique

        public ICollection<HoldingInfo> HoldingInfo { get; set; }


    }
}

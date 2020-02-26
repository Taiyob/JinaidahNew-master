using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jinaidah.Models
{
    public class HoldingType
    {
        public int Id { get; set; }
        
        [Display(Name = "Holding Type")]
        [Required]
        public string TypeName { get; set; } //Unique


        public ICollection<HoldingInfo> HoldingInfo { get; set; }
        public ICollection<WaterRate> WaterRate { get; set; }



    }
}

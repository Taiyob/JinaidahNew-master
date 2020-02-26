using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jinaidah.Models
{
    public class WaterConnection
    {
        public int Id { get; set; }
        [Display(Name = "Holding ID")]
        [Required]
        public int HoldingInfoId { get; set; }
        
        [Display(Name = "Dia Size")]
        [Required]
        public double ConnectionDia { get; set; }
        [Display(Name ="Connection Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime ConnectionDate { get; set; }

        [Display(Name ="Floor Number")]
        [Required]        
        public int FloorNos { get; set; }
        public bool IsActive { get; set; }
        public ICollection<WaterRate> WaterRate { get; set; }
        public HoldingInfo HoldingInfo { get; set; }


    }
}


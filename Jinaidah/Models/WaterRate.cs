using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jinaidah.Models
{
    public class WaterRate
    {
        public int Id { get; set; }
        public int HoldingTypeId { get; set; }
        public int WaterConnectionId { get; set; }
       
        [Required]
        public double Rate { get; set; }
        [Display(Name ="Floor Number")]
        [Required]
        public int FloorNos { get; set; }
        [Required]
        public double FloorRate { get; set; }
        [Display(Name ="Fine Rate")]
        [Required]
        public double FineRate { get; set; }
        public bool IsActive { get; set; }
       
        public DateTime InsertDate { get; set; }
        public string InsertBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Remark { get; set; }
        public HoldingType HoldingType  { get; set; }
        public WaterConnection WaterConnection { get; set; }

    }
}

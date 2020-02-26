using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jinaidah.Models
{
    public class Road
    {
        public int Id { get; set; }
        [Display(Name = "Ward No")]
        [Required]
        public int WardId { get; set; }
        [Display(Name = "Road No")]
        [Required]
        public int RoadNo { get; set; }
        [Display(Name = "Road Name")]
        public string RoadName { get; set; }

        public Ward Ward { get; set; }
       
        public ICollection<HoldingInfo> HoldingInfo { get; set; }



    }
}

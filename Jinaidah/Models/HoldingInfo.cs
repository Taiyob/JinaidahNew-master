using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jinaidah.Models
{
    public class HoldingInfo
    {
        public int Id { get; set; }
       
        [Display(Name = "Holding No")]
        [Required]
        public string HoldingNo { get; set; }//unique 
        [Display(Name = "Client Id")]
        [Required]
        public int ClientInfoId { get; set; }
        [Display(Name = "Holding Type")]
        [Required]
        public int HoldingTypeId { get; set; }
        [Display(Name = "Holding Category")]
        [Required]
        public int HoldingCategoryId { get; set; }
        [Display(Name = "Ward No")]
        [Required]
        public int WardId { get; set; }
        [Display(Name = "Road No")]
        [Required]
        public int RoadId { get; set; }
        [Required]
        public string Address { get; set; }
        [Display(Name = "Meter No")]

        public int MeterNo { get; set; }
       
       
        public string Floor { get; set; }
        public string Flat { get; set; }
        [Display(Name = "assessment Value")]
        public double AssetValue { get; set; }
        public string Status { get; set; }

        [Display(Name = "Effected Date")]
        public DateTime EffectDate { get; set; }
        [Display(Name = "Division")]

        public int DivisionId { get; set; }
        [Display(Name = "District")]
        public int DistrictId { get; set; }
        [Display(Name = "Upzilla")]
        public int UpzillaId { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Remark { get; set; }
        
        public ClientInfo ClientInfo { get; set; }
       
        public HoldingType HoldingType { get; set; }
        public HoldingCategory HoldingCategory { get; set; }
        public Ward Ward { get; set; }
        public Road Road { get; set; }
        public District District { get; set; }
        public Division Division { get; set; }
        public Upzilla Upzilla { get; set; }
        public ICollection<WaterConnection> WaterConnection { get; set; }

    }
}

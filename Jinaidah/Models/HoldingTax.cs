using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jinaidah.Models
{
    public class HoldingTax
    {
        public int Id { get; set; }
        [Display(Name = "Holding Id")]
        public int HoldingInfoId { get; set; }
        [Display(Name = "Holding Type")]
        public int HoldingTypeId { get; set; }
        [Display(Name = "Tax Item Name")]
        public int TaxItemSettingId { get; set; }
        [Required]
        public double Rate { get; set; }
        [Display(Name = "Tax Amount")]
        public double TaxAmount { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Remark { get; set; }

        public HoldingInfo HoldingInfo { get; set; }
        public HoldingType HoldingType { get; set; }
        public TaxItemSetting TaxItemSetting { get; set; }
        public TaxRate TaxRate { get; set; }
  


    }
}

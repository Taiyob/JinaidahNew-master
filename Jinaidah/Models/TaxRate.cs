using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Jinaidah.Models
{
    public class TaxRate
    {
        public int Id { get; set; }
        [Display(Name = "Tax Item")]
        public int TaxItemSettingId { get; set; }
        [Display(Name = "Holding  Type")]
        public int HoldingTypeId { get; set; }
        [Display(Name = "Holding  Categaory")]
        public int HoldingCategoryId { get; set; }
        public double Rate { get; set; }


        public TaxItemSetting TaxItemSetting { get; set; }
        public HoldingType HoldingType { get; set; }
        public HoldingCategory HoldingCategory { get; set; }
        public ICollection<TaxBill> TaxBill { get; set; }
    }
}

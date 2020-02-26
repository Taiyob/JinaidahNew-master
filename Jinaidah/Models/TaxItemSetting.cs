using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jinaidah.Models
{
    public class TaxItemSetting
    {
        public int Id { get; set; }
        [Display(Name = "Item Name")]
        [Required]
        public string ItemName { get; set; }      
        public DateTime InsertDate { get; set; }
        public string InsertBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Remark { get; set; }


        public ICollection<TaxRate> TaxRate { get; set; }
        public ICollection<HoldingTax> HoldingTax { get; set; }
    }
}

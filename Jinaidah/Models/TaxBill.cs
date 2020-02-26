using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jinaidah.Models
{
    public class TaxBill
    {
        public int Id { get; set; }
        [Display(Name = "Holding Id")]
        [Required]
        public int HoldingInfoId { get; set; }
        [Display(Name = "Tax Item")]
        [Required]
        public int TaxItemSettingId { get; set; }
        [Display(Name = "Bill No")]
        [Required]
        public string BillNo { get; set; }
        [Required]
        public double TaxRateId { get; set; }
        [Display(Name = "Bill Amount")]
        [Required]
        public double BillAmount { get; set; }
        public double Rebate { get; set; }
        public double Discount { get; set; }
        [Display(Name = "Paid Amount")]
        public double PaidAmount { get; set; }
        [Display(Name = "UnPaid Amount")]
        public double UnPaidAmount { get; set; }
    
        public bool Ispaid { get; set; } = false;

        [DataType(DataType.Date)]
        [Display(Name = "Paid Date")]

        public DateTime PaidDate { get; set; }
       
       
         
        
        [Flags]
        public enum Installment//
        { 
            Dues=0,//for previous accumulated dues
            Q1 = 1,
            Q2 = 2,
            Q3 = 3,
            Q4 = 4,
        }
        [Display(Name = "Paid By")]
        public string PaidBy { get; set; }
        public double SurCharge { get; set; }
        [Display(Name = "Service Charge")]
        public double ServiceCharge { get; set; }
        [Display(Name = "Month Year")]
        public string MonthYear { get; set; }     
        public DateTime InsertDate { get; set; }
        public string InsertBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Remark { get; set; }

        public HoldingInfo HoldingInfo { get; set; }
        public TaxItemSetting TaxItemSetting { get; set; }
        public TaxRate TaxRate { get; set; }

    }
}

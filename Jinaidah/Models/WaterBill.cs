using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jinaidah.Models
{
    public class WaterBill
    {
        public int Id { get; set; }
        [Required]
        public int HoldingInfoId { get; set; }
        public string MeterNo { get; set; }
        [Display(Name ="Bill No")]
        [Required]
        public string BillNo { get; set; }
        [Display(Name ="Month Of Bill")]
        [Required]
        public string BillMonth { get; set; }
        [Display(Name ="Billing Year")]
        [Required]
        public string BillYear { get; set; }
        public double Unit { get; set; }
        public double SurCharge { get; set; }
        public double Others { get; set; }
        public double Fine { get; set; }
        public double Due { get; set; }
        public double PreReading { get; set; }
        public DateTime PreReadingDate { get; set; }
        public double CurrentReading { get; set; }
        public DateTime CurrentReadingDate { get; set; }
        public double NetReading { get; set; }
        public double Discount { get; set; }
        [Display(Name ="Bill Amount")]
        [Required]
        public double BillAmount { get; set; }
        [Display(Name = "Paid Amount")]
        public double PaidAmount { get; set; }
        [Display(Name = "Unpaid Amount")]
        public double UnPaidAmount { get; set; }

        public bool IsPaid { get; set; } = false;
        [Display(Name = "Paid Date")]
        [DataType(DataType.Date)]
        public DateTime PaidDate { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Remark { get; set; }

        public HoldingInfo HoldingInfo { get; set; }
    }
}

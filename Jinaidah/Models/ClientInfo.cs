using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jinaidah.Models
{
    public class ClientInfo
    {
        public int Id { get; set; }
        [Display(Name ="Client Id")]
        [Required]
        public string UserId { get; set; }//
        [Display(Name = "Client Name")]
        [Required]
        public string ClientName { get; set; }//
        [Display(Name = "Client Type")]

        public string ClientType { get; set; }
        public string Father { get; set; }
        public string Husband { get; set; }
        [Display(Name = "Verification Code")]
        public int verifyCode { get; set; }
        public bool Verified { get; set; } = false;
        [Required]
        public string Address { get; set; }//
        [Display(Name = "Division")]
        [Required]
        public int DivisionId { get; set; }
        [Display(Name = "District")]
        [Required]
        public int DistrictId { get; set; }
        [Display(Name = "Upzilla")]
        [Required]
        public int UpzillaId { get; set; }
        [Required]
        public string NID { get; set; }//Unique and required
        [EmailAddress]
        public string Email { get; set; }
        public string PWD { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Mobile Number")]        
        
        public string MobileNo { get; set; }//Unique and required
        public string ClientAttachment { get; set; }//attach file link
        public bool IsActive { get; set; } = false;
        public DateTime InsertDate { get; set; }
        public string InsertBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Remark { get; set; }


        public ICollection<HoldingInfo>  holdingInfo { get; set; }
        public Ward Ward { get; set; }//
        public Road Road { get; set; }//
        public District District { get; set; }//
        public Division Division { get; set; }//
        public Upzilla Upzilla { get; set; }//


    }
}

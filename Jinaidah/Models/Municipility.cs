using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jinaidah.Models
{
    public class Municipility
    {
        public int Id { get; set; }
        [Display(Name = "Municipility Name")]
        [Required]
        public string MName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Fax { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string logo { get; set; }


        public ICollection<Ward> Ward { get; set; }
       
    }
}

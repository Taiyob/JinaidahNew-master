using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jinaidah.Models
{
    public class Ward
    {
        public int Id { get; set; }
        [Required]
        public int MunicipilityId { get; set; }
        [Display(Name = "Ward No")]
        [Required]
        public int WardNo { get; set; }
        [Display(Name = "Ward Name")]
        public string WardName { get; set; }


        public Municipility Municipility { get; set; }
        public ICollection<Road> Road { get; set; }
    }
}

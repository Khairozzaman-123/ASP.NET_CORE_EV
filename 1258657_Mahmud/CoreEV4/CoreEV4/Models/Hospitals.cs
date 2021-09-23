using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEV4.Models
{
    public class Hospitals
    {
        public Hospitals()
        {
            this.Patients = new HashSet<Patients>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int hId { get; set; }
        [Display(Name = "Hospital Name")]
        public string hName { get; set; }
        [Display(Name = "Address")]
        public string hAddress { get; set; }

        //nav
        public virtual ICollection<Patients> Patients { get; set; }
    }
}

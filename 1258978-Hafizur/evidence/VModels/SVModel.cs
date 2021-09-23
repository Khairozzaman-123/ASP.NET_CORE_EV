using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace evidence.VModels
{
    public class SVModel
    {
        public int studentId { get; set; }
        [Required, StringLength(50)]
        [Display(Name = "Student Name")]
        public string studentName { get; set; }
        public string ImageName { get; set; }
        [Required, StringLength(250)]
        [Display(Name = "Picture Path")]
        public string picturePath { get; set; }
        [Required]
        [ForeignKey("department")]
        public int departmentId { get; set; }
        [Required]
        [Display(Name = "Admission Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Column(TypeName = ("date"))]
        public DateTime AdmissionDate { get; set; }
    }
}

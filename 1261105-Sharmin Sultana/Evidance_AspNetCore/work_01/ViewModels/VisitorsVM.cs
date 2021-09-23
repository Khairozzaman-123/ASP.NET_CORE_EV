using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using work_01.CustomValidation;

namespace work_01.ViewModels
{
    public class VisitorsVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the name."), StringLength(50), Display(Name = "Visitor Name")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string VisitorName { get; set; }
        [Required(ErrorMessage = "Please enter the city."), ForeignKey("City")]
        [Display(Name = "City")]
        public int cId { get; set; }
        [Required(ErrorMessage = "Please enter the contact no."), StringLength(20), Display(Name = "Visitor Contact")]
        [RegularExpression("^[+0-9]*$",ErrorMessage = "Only Numbers allowed for Contact no.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter Visit Date."), Display(Name = "Visit Date")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [CustomVisitDate(ErrorMessage = "Visit Date can't be less than to Today's Date.")]
        public DateTime VisitDate { get; set; }
        public string cName { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
    }
}

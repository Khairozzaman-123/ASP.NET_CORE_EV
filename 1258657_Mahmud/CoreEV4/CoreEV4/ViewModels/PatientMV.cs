using CoreEV4.CustomValidation;
using CoreEV4.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEV4.ViewModels
{
    public class PatientMV
    {
        public int pId { get; set; }
        [Required, StringLength(50)]
        [DisplayName("Name")]
        public string pName { get; set; }
        [Required, CustomEmailValidator]
        [DisplayName("Email")]
        public string pEmail { get; set; }
        [DisplayName("Blood Group")]
        public string bGroup { get; set; }
        [Required, DisplayName("Date of birth")]
        public DateTime Dob { get; set; }
        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }
        public string img { get; set; }
        [DisplayName("Image")]
        public IFormFile pImageFile { get; set; }
        [Required]
        [DisplayName("Status")]
        public string pStatus { get; set; }
        [Required]
        [DisplayName("Assigned Hospital")]
        [ForeignKey("Hospitals")]
        public int hId { get; set; }
        public virtual Hospitals Hospitals { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using work_01.CustomValidation;
using Microsoft.EntityFrameworkCore;

namespace work_01.Models
{
    public class City
    {
        public City()
        {
            Visitors = new List<Visitor>();
        }
        [Key]
        public int cId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the city name"), StringLength(50), Display(Name = "City")]
        public string cName { get; set; }
        public virtual ICollection<Visitor> Visitors { get; set; }
    }
    public class Visitor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the name."), StringLength(50), Display(Name = "Visitor Name")]
        public string VisitorName { get; set; }
        [Required(ErrorMessage = "Please enter the city."), ForeignKey("City")]
        [Display(Name = "City")]
        public int cId { get; set; }
        [Required(ErrorMessage = "Please enter the contact no."), StringLength(20), Display(Name = "Visitor Contact")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter Visit Date."), Display(Name = "Visit Date")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [CustomVisitDate(ErrorMessage = "Visit Date can't be less than to Today's Date.")]
        public DateTime VisitDate { get; set; }
        public string Image { get; set; }
        //Navigation
        public virtual City City { get; set; }
    }
    public class VisitorDbContext : DbContext
    {
        public VisitorDbContext(DbContextOptions<VisitorDbContext> options) : base(options)
        {

        }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}

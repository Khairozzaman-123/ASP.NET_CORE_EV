using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace evidence.Models
{
    public class Department
    {
        public int departmentId { get; set; }
        [Required, StringLength(50), Display(Name = "Department Name")]
        public string departmentName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
    public class Student
    {
        public int studentId { get; set; }
        [Required, StringLength(50)]
        [Display(Name = "Student Name")]
        public string studentName { get; set; }
        [Required, StringLength(250)]
        [Display(Name = "Picture Path")]
        public string picturePath { get; set; }
        [Required]
        [ForeignKey("department")]
        public int departmentId { get; set; }
        [Required]
        [Display(Name = "Admission Date")]
        [Column(TypeName = ("date"))]
        public DateTime admissionDate { get; set; }
        public virtual Department department { get; set; }
    }
    public class DepartmentDbContext : DbContext
    {
        public DepartmentDbContext(DbContextOptions<DepartmentDbContext> options) : base(options)
        {

        }
        public DbSet<Department> departments { get; set; }
        public DbSet<Student> Students { get; set; }
       
    }
}

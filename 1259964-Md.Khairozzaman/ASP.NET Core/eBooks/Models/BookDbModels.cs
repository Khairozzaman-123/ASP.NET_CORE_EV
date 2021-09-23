using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eBooks.Models
{
    internal sealed class OptionalAttribute : Attribute { }
    public class Publisher
    {
        public int PublisherId { get; set; }
        [Required]
        [Display(Name ="Publisher Name")]
        [StringLength(50)]
        public string PublisherName { get; set; }

#nullable enable
        [Display(Name = "Publisher Address")]
        [StringLength(50)]
        public string? PublisherAddress { get; set; }
#nullable disable

        public ICollection<Book> Books { get; set; }
    }

    public class Book
    {
        public int BookId { get; set; }
        [Required(ErrorMessage = "Book Name is Required"),Display(Name = "Book Name")]
        [StringLength(50)]
        public string BookName { get; set; }
        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        [Column(TypeName = ("date")), DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}",ApplyFormatInEditMode =true), Display(Name = "Published Date")]
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        [Column(TypeName ="money")]
        public decimal Price { get; set; }
        [Display(Name = "Cover Image")]
        public string CoverImage { get; set; }
        [Optional]
        public string BookRating { get; set; }

        public Publisher Publisher { get; set; }
    }

    public class BookDbContext : DbContext
    {
       public BookDbContext(DbContextOptions<BookDbContext> options):base(options)
        {

        }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; } 
    }
}

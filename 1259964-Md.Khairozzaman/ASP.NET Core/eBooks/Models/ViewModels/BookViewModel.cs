using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestService.CustomValidation;

namespace eBooks.Models.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int PublisherId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [LessDate]
        public DateTime PublishDate { get; set; }
        public decimal Price { get; set; }
        public string CoverImage { get; set; }
        public IFormFile Picture { get; set; }
        public string BookRating { get; set; }

    }
}

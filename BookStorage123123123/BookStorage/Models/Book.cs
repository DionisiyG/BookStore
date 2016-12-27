using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStorage.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }        
        [DisplayName("Year of Publish")]
        [Required]
        public int YearPublish{ get; set; }
        [Required]
        public int Price { get; set; }

        [DisplayName("Author")]
        public int? AuthorId { get; set; } //FK
        public Author Author { get; set; } //navigation property
        public IEnumerable<SelectListItem> AuthorList { get; set; }
    }
}
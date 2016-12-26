using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStorage.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearPublish{ get; set; }
        public int Price { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; } //navigation property
    }
}
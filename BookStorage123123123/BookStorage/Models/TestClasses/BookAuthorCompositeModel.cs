using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStorage.Models
{
    public class BookAuthorCompositeModel
    {
        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
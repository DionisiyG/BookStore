using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStorage.Models
{
    public class BookAuthorCompositeModel
    {
        public Author author { get; set; }
        public Book book { get; set; }
    }
}
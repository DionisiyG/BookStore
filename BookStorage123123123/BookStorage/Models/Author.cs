using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStorage.Models
{
    public class Author
    {
        public int Id { get; set; }        
        [Required]
        [DisplayName("Author")]
        public string AuthorName { get; set; }

        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<SelectListItem> AuthorList { get; set; }

    }
}
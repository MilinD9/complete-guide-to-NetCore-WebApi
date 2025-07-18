﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_books_store.Data.Models;

namespace my_books_store
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int Rate { get; set; }
        public string Genre { get; set; }
        //public string Author { get; set; } //add authors test thorugh controller
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }

        //Navigation Properties
        public int? PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public List<Book_Author> Book_Authors { get; set; }

    }
}

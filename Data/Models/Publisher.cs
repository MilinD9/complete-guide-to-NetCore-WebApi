﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_store.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }
       
    }
}

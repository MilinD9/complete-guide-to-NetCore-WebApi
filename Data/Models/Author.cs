using System.Collections.Generic;

namespace my_books_store.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string fullName { get; set; }

        //Naviigation properties
        public List<Book_Author> Book_Authors { get; set; }
    }
}

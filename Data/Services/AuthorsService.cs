using my_books_store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_store.Data.Services
{
    public class AuthorsService
    {
        private appDbContext _context;

        public AuthorsService(appDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM book)
        {
            var _author = new Author()
            {
                fullName = book.Name
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorwithBooksVM GetAuthorwithBooks(int authordId)
        {
            var _author = _context.Authors.Where(n=>n.Id==authordId).Select(n=> new AuthorwithBooksVM()
            {
                FullName =n.fullName,
                BookTitles=n.Book_Authors.Select(n=>n.Book.Title).ToList()

            }).FirstOrDefault();
            return _author;
        }
    }
}

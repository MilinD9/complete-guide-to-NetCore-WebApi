using my_books_store.Data.Models;
using my_books_store.Data.userViewModaes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_store.Data.Services
{
    public class BookService
    {
        private appDbContext _context;

        public BookService(appDbContext context)
        {
            _context = context;
        }

        public void AddBook(NewBooks book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                //Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateRead = book.IsRead ? book.DateRead : null,
                Rate = book.IsRead ? book.Rate : 0,
                Genre = book.Genre,
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks() => _context.Books.ToList();

        //public Book getBookById(int bookId) => _context.Books.FirstOrDefault(n => n.Id == bookId); //* OLD METHOD getBookById

        public Book UpdatebookById(int bookId, NewBooks book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                // _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;
                _book.DateRead = book.IsRead ? book.DateRead : null;
                _book.Rate = book.IsRead ? book.Rate : 0;
                _book.Genre = book.Genre;
                _context.SaveChanges();
            }
            return _book;
        }


        public Book DeletebookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
            return _book;
        }


        public void AddBookWithAuthors(NewBooks book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                //Author = book.Author, //<< Commented for check test Auther add authors 
                CoverUrl = book.CoverUrl,
                DateRead = book.IsRead ? book.DateRead : null,
                Rate = book.IsRead ? book.Rate : 0,
                Genre = book.Genre,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();

            }

        }


        public BookWithAuthorsVM getBookById(int bookId)  //* NEW METHOD getBookById
        {
            var _bookwithAuthors = _context.Books.Where(n=> n.Id==bookId).Select(book => new BookWithAuthorsVM()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                CoverUrl = book.CoverUrl,
                DateRead = book.IsRead ? book.DateRead : null,
                Rate = book.IsRead ? book.Rate : 0,
                Genre = book.Genre,
                PublisherName=book.Publisher.Name,
                AuthorNames=book.Book_Authors.Select(n=>n.Author.fullName).ToList()
            }).FirstOrDefault();
            return _bookwithAuthors;
        }

    }
}

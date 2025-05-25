using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books_store.Data.Services;
using my_books_store.Data.userViewModaes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookService _bs;

        public BooksController(BookService bookService)
        {
            _bs = bookService;
        }

        [HttpPost("addbook")]
        public IActionResult AddBook([FromBody]NewBooks book)
        {
            _bs.AddBook(book);
            return Ok();
        }

        [HttpGet("Get-All-Books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bs.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("Get-All-BooksbyId/{id}")]
        public IActionResult GetAllBooks(int id)
        {
            var book = _bs.getBookById(id);
            return Ok(book);
        }


        [HttpPut("Update-BooksbyId/{id}")]
        public IActionResult UpdateBookById(int id,[FromBody]NewBooks book)
        {
            var updatedBook = _bs.UpdatebookById(id,book);
            return Ok(updatedBook);
        }


        [HttpPut("Delete-BooksbyId/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            var deleteBook = _bs.DeletebookById(id);
            return Ok(deleteBook);
        }

        [HttpPost("addbook-with-authors")]
        public IActionResult AddBookWithAuthors([FromBody] NewBooks book)
        {
            _bs.AddBookWithAuthors(book);
            return Ok();
        }

    }
}

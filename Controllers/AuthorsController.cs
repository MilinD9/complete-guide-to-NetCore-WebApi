using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books_store.Data.Models;
using my_books_store.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-Authors")]
        public IActionResult AddBook([FromBody] AuthorVM Author)
        {
            _authorsService.AddAuthor(Author);
            return Ok();
        }

        [HttpGet("get-Authors-with-books-by-id/{id}")]
        public IActionResult GetAuthorwithBooks(int id)
        {
           var response= _authorsService.GetAuthorwithBooks(id);
            return Ok(response);
        }
    }
}

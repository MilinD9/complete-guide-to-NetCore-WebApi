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
    public class PublisherController : ControllerBase
    {
        private PublishersService _publisherService;

        public PublisherController(PublishersService publisherService)
        {
            _publisherService = publisherService;
        }

       

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers(string sortby,string searchstring, int pagenumber)
        {

            try
            {
                var _result = _publisherService.GetAllPublishers(sortby, searchstring, pagenumber);
                return Ok(_result);
            }
            catch (Exception)
            {

                return BadRequest("Sorry,we could not load the publishers");
            }
           
        }







        [HttpPost("addpublisher")]
        public IActionResult AddBook([FromBody] PublisherVM publisher)
        {
            _publisherService.AddPublisher(publisher);
            return Ok();
        }


        [HttpPost("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var r = _publisherService.GetPublisherData(id);
            return Ok(r);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherbyId(int id)
        {
             _publisherService.deletepublisherById(id);
            return Ok();
        }
    }
}

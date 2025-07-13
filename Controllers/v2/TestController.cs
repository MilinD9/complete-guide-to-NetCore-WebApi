using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_store.Controllers.v2
{
    [ApiVersion("2.0")]
    //[Route("api/[controller]")]  //<<Header Based 
    [Route("api/v{version:apiVersion}/[controller]")] //URL-based API versioning, also known as route-based versioning.
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("get-test-data")]
        public IActionResult Get()
        {
            return Ok("This is TestContoller for v2");
        }
    }
}

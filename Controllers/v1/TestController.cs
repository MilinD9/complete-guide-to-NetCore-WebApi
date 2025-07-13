using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_store.Controllers.v1
{
    //[ApiVersion("1.0")] //<<HTTP Based 
    //[ApiVersion("1.1")] //<<HTTP Based 
    //[ApiVersion("1.2")] //<<HTTP Based 
    //[ApiVersion("1.9")] //<<HTTP Based 
    //[Route("api/[controller]")]  //<<Header Based 
    ////[Route("api/v{version:apiVersion}/[controller]")] //<< URL-based API versioning, also known as route-based versioning.
    //[ApiController]
    //public class TestController : ControllerBase
    //{

    //    [HttpGet("get-test-data")]
    //    public  IActionResult Getv1()
    //    {
    //        return Ok("This is versioning for v1.0");
    //    }

    //    [HttpGet("get-test-data"),MapToApiVersion("1.1")]
    //    public IActionResult Getv11()
    //    {
    //        return Ok("This is versioning for v1.1");
    //    }
    //    [HttpGet("get-test-data"), MapToApiVersion("1.2")]
    //    public IActionResult Getv12()
    //    {
    //        return Ok("This is versioning for v1.2");
    //    }
    //    [HttpGet("get-test-data"),MapToApiVersion("1.9")]
    //    public IActionResult Getv19()
    //    {
    //        return Ok("This is versioning for v1.9");
    //    }
    //}



    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiVersion("1.2")]
    [ApiVersion("1.9")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("get-test-data")]
        public IActionResult Getv1() => Ok("This is versioning for v1.0");

        [HttpGet("get-test-data"), MapToApiVersion("1.1")]
        public IActionResult Getv11() => Ok("This is versioning for v1.1");

        [HttpGet("get-test-data"), MapToApiVersion("1.2")]
        public IActionResult Getv12() => Ok("This is versioning for v1.2");

        [HttpGet("get-test-data"), MapToApiVersion("1.9")]
        public IActionResult Getv19() => Ok("This is versioning for v1.9");
    }

}

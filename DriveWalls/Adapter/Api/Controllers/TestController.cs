using Microsoft.AspNetCore.Mvc;

namespace Adapter.Api.Controllers
{
    [Route("test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public String test()
        {
            Console.WriteLine("test");
            return ("test");
        }
    }
}
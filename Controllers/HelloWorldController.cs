using Microsoft.AspNetCore.Mvc;

namespace InsurancePolicyAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class HelloWorldController : ControllerBase
    {
        // GET: api/
        [HttpGet]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hello World");
        }
    }
}

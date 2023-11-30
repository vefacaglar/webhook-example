using Microsoft.AspNetCore.Mvc;

namespace webhook_example.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
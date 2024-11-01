using Microsoft.AspNetCore.Mvc;

namespace ServiceSphere.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/home
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Welcome to the ServiceSphere API!";
        }
    }
}

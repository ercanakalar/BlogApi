using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [ApiController]
    [Route("api/auth/signout")]
    public class SignoutController : ControllerBase
    {
        [HttpPost]
        public IActionResult Signout()
        {
            if (Request.Cookies.ContainsKey("auth"))
            {
                Response.Cookies.Delete("auth");
            }

            return Ok(new { message = "Signed out successfully." });
        }
    }
}

using Authorization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Authorization.Controllers
{

    [ApiController]
   
    public class AuthController : Controller
    {
        [HttpPost("LoginAPI")]
        public async Task<ActionResult<Response>> GetByLogin([FromBody] DocRequests log)
        {
            var result = await log.Log();
            return Ok(result);

        }
    }

}

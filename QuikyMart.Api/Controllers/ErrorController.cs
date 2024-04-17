using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuikyMart.Service.ExceptionsHandeling;

namespace QuikyMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        public IActionResult error(int code)
        {
            return NotFound(new ApiResponse(code , "This End Point Is Not Found"));
        }
    }
}

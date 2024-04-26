using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuikyMart.Data.Entites;

namespace QuikyMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeGenerationController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetGenerationCode([FromServices] GenerationCode generator)
        {
            var generatedCode = generator.Create();
            return Ok(generatedCode);
        }
    }
}

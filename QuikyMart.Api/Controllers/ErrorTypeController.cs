using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuikyMart.Data.DB.Context;
using QuikyMart.Repositores.Interfaces;
using QuikyMart.Service.ExceptionsHandeling;

namespace QuikyMart.Api.Controllers
{

    public class ErrorTypeController : BaseCont
    {
        private readonly QuikyMartDBContext _context;

        public ErrorTypeController(QuikyMartDBContext context)
        {
            _context = context;
        }


        [HttpGet("notfound")]
        public IActionResult GetNotFound()
        {
            return NotFound(new ApiResponse(404));
        }

        [HttpGet("BadRequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }


        [HttpGet("BadRequest/{id}")]
        public IActionResult GetBadRequest(int id)
        {
            var product = _context.Products.Find(100);

            return Ok(product);
        }

        [HttpGet("ServerError")]
        public IActionResult GetServerError()
        {
            var product = _context.Products.Find(100);
            var error = product.ToString();
            return Ok(error);
        }


        [HttpGet("Unauthorized")]
        public IActionResult GetUnauthorized()
        {
            return Unauthorized(new ApiResponse(401));
        }

    }
}

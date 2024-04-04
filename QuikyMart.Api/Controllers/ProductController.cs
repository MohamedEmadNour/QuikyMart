using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuikyMart.Data.Entites;
using QuikyMart.Repositores.Interfaces;
using QuikyMart.Repositories.Interfaces;

namespace QuikyMart.Api.Controllers
{

    public class ProductController : BaseCont
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork  /* , IGenericRepositories<Product , int> genericRepositories*/)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetAllProduct()
        {
            var products = await _unitOfWork.repositories<Product , int>().GetAllAsync();

            return Ok(products);
        }

        [HttpGet]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _unitOfWork.repositories<Product, int>().GetByIdAsync(id);

            return Ok(product);
        }


    }
}

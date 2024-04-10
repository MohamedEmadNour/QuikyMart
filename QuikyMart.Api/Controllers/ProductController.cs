using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuikyMart.Data.Entites;
using QuikyMart.Repositores.Interfaces;
using QuikyMart.Repositores.Specifications.ProductSpecificationsProfile;
using QuikyMart.Repositories.Interfaces;
using QuikyMart.Service.Dtos;

namespace QuikyMart.Api.Controllers
{

    public class ProductController : BaseCont
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(
            IUnitOfWork unitOfWork  
            /* , IGenericRepositories<Product , int> genericRepositories*/
            , IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct([FromQuery]ProductSpec input)
        {
            var spec = new ProductWithSpecification(input);
            //var products = await _unitOfWork.repositories<Product , int>().GetAllAsync();
            var products = await _unitOfWork.repositories<Product , int>().GetAllWithSpecificatioAsync(spec);
            var ProductMapping = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return Ok(ProductMapping);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var spec = new ProductWithSpecification(id);

            var product = await _unitOfWork.repositories<Product, int>().GetByIdWithSpecificatioAsync(spec);
            var ProductMapping = _mapper.Map<Product, ProductDTO>(product);

            return Ok(ProductMapping);
        }





    }
}

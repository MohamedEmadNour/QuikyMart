using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuikyMart.Data.Entites;
using QuikyMart.Repositores.Interfaces;

namespace QuikyMart.Api.Controllers
{

    public class BrandTypeController : BaseCont
    {
        private readonly IUnitOfWork _unitOfWork;
  

        public BrandTypeController(
            IUnitOfWork unitOfWork

            )
        {
            _unitOfWork = unitOfWork;
 
        }

        [HttpGet("GetAllType")]
        public async Task<ActionResult> GetProductType()
        {
            var types = await _unitOfWork.repositories<ProductType , int>().GetAllAsync();

            return Ok(types);

        }
        [HttpGet("GetAllBrands")]
        public async Task<ActionResult> GetProductBrand()
        {
            var Brands = await _unitOfWork.repositories<ProductBrand, int>().GetAllAsync();
            return Ok(Brands);

        }

    }
}

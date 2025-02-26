﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuikyMart.Api.Helper;
using QuikyMart.Data.Entites;
using QuikyMart.Repositores.Interfaces;
using QuikyMart.Repositores.Specifications.ProductSpecificationsProfile;
using QuikyMart.Repositories.Interfaces;
using QuikyMart.Service.Dtos;
using QuikyMart.Service.ExceptionsHandeling;

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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetAllProduct([FromQuery]ProductSpec input)
        {
            var spec = new ProductWithSpecification(input);
            //var products = await _unitOfWork.repositories<Product , int>().GetAllAsync();
            var products = await _unitOfWork.repositories<Product , int>().GetAllWithSpecificatioAsync(spec);
            var ProductMapping = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products);
            var CountSpec = new ProductCountSpic(input);
            int Count = await _unitOfWork.repositories<Product, int>().GetCountSpecificatio(CountSpec); 

            return Ok(new Pagination<ProductDTO>(input.pageSize, input.pageIndex, Count, ProductMapping));
        }


        [Authorize]
        [ProducesResponseType(typeof(ProductDTO), statusCode:200)]
        [ProducesResponseType(typeof(ProductDTO), statusCode:404)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var spec = new ProductWithSpecification(id);


            var product = await _unitOfWork.repositories<Product, int>().GetByIdWithSpecificatioAsync(spec);
            if (product is null)
                return NotFound(new ApiResponse(404));
            var ProductMapping = _mapper.Map<Product, ProductDTO>(product);

            return Ok(ProductMapping);
        }





    }   
}

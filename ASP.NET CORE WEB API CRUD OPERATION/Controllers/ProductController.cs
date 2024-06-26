using ASP.NET_CORE_WEB_API_CRUD_OPERATION.Configurations;
using ASP.NET_CORE_WEB_API_CRUD_OPERATION.Contracts;
using ASP.NET_CORE_WEB_API_CRUD_OPERATION.Data.Models;
using ASP.NET_CORE_WEB_API_CRUD_OPERATION.DTOs.Category;
using ASP.NET_CORE_WEB_API_CRUD_OPERATION.DTOs.Product;
using ASP.NET_CORE_WEB_API_CRUD_OPERATION.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_WEB_API_CRUD_OPERATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductController(IMapper mapper,
            IProductRepository productRepository)
        {
            this._mapper = mapper;
            this._productRepository = productRepository;

        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateCategory(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            await this._productRepository.CreateAsync(product);

            return CreatedAtAction("GetProduct", new { id = product.CategoryId }, product);
        }


        // GET: api/GetCategory/1
        [HttpGet("GetProduct")]
        public async Task<ActionResult<GetProductDetailsDto>> GetProduct(int productId)
        {
            var product = await this._productRepository.GetAsync(productId);

            if (product == null)
            {
                throw new Exception($"ProductID {productId} is not found.");
            }

            var productDetailsDto = _mapper.Map<GetProductDetailsDto>(product);

            return Ok(productDetailsDto);
        }

    }
}

using _4Tables.Base;
using _4Tables2._0.Domain.Base.Common;
using _4Tables2._0.Domain.Base.Result;
using _4Tables2._0.Domain.ProductDomain.Dto;
using _4Tables2._0.Domain.ProductDomain.Entity;
using _4Tables2._0.Domain.ProductDomain.Enum;
using _4Tables2._0.Domain.ProductDomain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace _4Tables.ControllerProduct.Product
{
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result))] 
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))] 
        public async Task<ActionResult> Add([FromBody] List<ProductRequestDTO> productsDto)
        {
            var result = await _productService.AddProductInRangeAsync(productsDto);

            return 
                StatusCode(result.StatusCode, result);
        }

        [HttpPost("ActiveDesactive/{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        public async Task<ActionResult> ActiveDesactive([FromRoute] long id)
        {
            var result = await _productService.ActiveOrDesativeProduct(id);

            return
                StatusCode(result.StatusCode, result);
        }

        [HttpGet("Actives")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductResponseDto))]
        public async Task<ActionResult> FindAllActives()
        {
            var result = await _productService.GetAllProductsActivesAsync();
            return 
                StatusCode(result.StatusCode, result);
        }

        [HttpGet("Desactives")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductResponseDto))]
        public async Task<ActionResult> FindAllDesactives()
        {
            var result = await _productService.GetAllProductsDesactivesAsync();
            return 
                StatusCode(result.StatusCode, result);
        }

        [HttpGet("{category:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductResponseDto))]
        public async Task<ActionResult> FindAllByCategory(int category)
        {
            var result = await _productService.GetAllProductsByCategoryAsync((EProductCategory)category);
            return 
                StatusCode(result.StatusCode, result);
        }
    }
}

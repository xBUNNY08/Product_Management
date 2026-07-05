using First_Crud.DTOS;
using First_Crud.Modals;
using First_Crud.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace First_Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService service)
        {
            productService = service;
        }

        //For Add Product
        [HttpPost("create-product")]
        public IActionResult AddProduct(ProductRequired product)
        {
            var response = productService.AddProduct(product);

            return Ok(response);
        }

        //For Get All Products
        [HttpGet("get-all-product")]
        public IActionResult GetProducts()
        {    
            return Ok(productService.GetProducts());
        }

        //For Get Product By ID
        [HttpGet("get-product-by-id")]
        [Route("{Id}")]
        public IActionResult GetProductById(int Id)
        {
            var response = productService.GetProductById(Id);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        //For Update Product
        [HttpPut("update-product")]
        public IActionResult UpdateProduct(Product product)
        {
            var response = productService.UpdateProduct(product);

            if (response.isFailure)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        //For Delete Product
        [HttpDelete("delete-product")]
        public IActionResult DeleteProduct(int Id)
        {
            try
            {
                productService.DeleteProduct(Id);
                return Ok("Product Deleted Successfully");
            }
            catch
            {
                return NotFound();
            }
        }

    }
}

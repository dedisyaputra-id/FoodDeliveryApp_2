using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using webapifirst.Models;
using webapifirst.Service;

namespace webapifirst.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly FoodDeliveryContext _db;
        private readonly IProductService _productService;
        public ProductController(FoodDeliveryContext context, IProductService productService) 
        {
            _db = context;
            _productService = productService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _productService.Get();
                return Ok(products);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            try
            {
                var product = _productService.GetById(id);
                if (product != null)
                {
                    return Ok(product);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Save([FromForm] ProductDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _productService.Add(model);
                var product = _productService.Get();
                return Ok(new { success = true, message = "Successfully save data", data = product });
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromBody] string ProductId)
        {
            try
            {
                _productService.Delete(ProductId);
                return Ok(new { success = true, message = "Successfully delete data" });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

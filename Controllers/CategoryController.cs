using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapifirst.Models;
using webapifirst.Repository;
using webapifirst.Service;

namespace webapifirst.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService categoryService) 
        { 
            _service = categoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var category = _service.Get();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetById([FromRoute] string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest();
                }

                var category = _service.GetById(id);

                if (category != null)
                {
                    return Ok(category);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Save([FromForm] CategoryDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _service.Add(model);
                var categories = _service.Get();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromBody] string categoryId)
        {
            try
            {
                if (string.IsNullOrEmpty(categoryId))
                {
                    return NotFound();
                }
                
                var oObject = _service.UpdateDlt(categoryId);
                return Ok(oObject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

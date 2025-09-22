using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapifirst.Models;

namespace webapifirst.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly FoodDeliveryContext _db;
        public CategoryController(FoodDeliveryContext context) 
        { 
            _db = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var category = _db.Categories.ToList().Where(c => c.dlt == 0);
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
                var category = _db.Categories.Find(id);
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
                var oObject = new Category();
                if (string.IsNullOrEmpty(Convert.ToString(model.CategoryId)))
                {
                    oObject.CategoryId = Convert.ToString(Guid.NewGuid());
                    oObject.OpAdd = "Admin";
                    oObject.PcAdd = Environment.MachineName;
                    oObject.DateAdd = DateTime.Now;

                    _db.Categories.Add(oObject);
                }
                else
                {
                    oObject = _db.Categories.Find(Convert.ToString(model.CategoryId));
                    if (oObject != null)
                    {
                        oObject.OpEdit = "admin";
                        oObject.PcEdit = Environment.MachineName;
                        //oObject.DateEdit = DateTime.Now;
                    }
                }
                if (oObject != null)
                {
                    oObject.Name = model.Name;
                }
                _db.SaveChanges();
                return Ok(oObject);
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
                var oObject = _db.Categories.Find(categoryId);
                if (oObject != null)
                {
                    oObject.dlt = 1;
                    oObject.OpEdit = "admin";
                    oObject.PcEdit = Environment.MachineName;
                    //oObject.DateEdit = Convert.ToString(DateTime.Now);
                    _db.SaveChanges();
                    return Ok(oObject);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

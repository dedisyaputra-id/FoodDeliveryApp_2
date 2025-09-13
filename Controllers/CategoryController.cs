using Microsoft.AspNetCore.Mvc;
using webapifirst.Models;

namespace webapifirst.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        public CategoryController() { }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using(var db = new FoodDeliveryContext())
                {
                    var category = db.Categories.ToList().Where(c => c.dlt == 0);
                    return Ok(category);
                }
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
                using( var db = new FoodDeliveryContext())
                {
                    var category = db.Categories.Find(id);
                    if(category != null)
                    {
                        return Ok(category);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Save([FromForm] CategoryDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                using (var db = new FoodDeliveryContext())
                {
                    var oObject = new Category();
                    if (string.IsNullOrEmpty(Convert.ToString(model.CategoryId)))
                    {
                        oObject.CategoryId = Convert.ToString(Guid.NewGuid());
                        oObject.OpAdd = "Admin";
                        oObject.PcAdd = Environment.MachineName;
                        oObject.DateAdd = DateTime.Now;

                        db.Categories.Add(oObject);
                    }
                    else
                    {
                        oObject = db.Categories.Find(Convert.ToString(model.CategoryId));
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
                    db.SaveChanges();
                    return Ok(oObject);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] string categoryId)
        {
            try
            {
                if (string.IsNullOrEmpty(categoryId))
                {
                    return NotFound();
                }
                using (var db = new FoodDeliveryContext())
                {
                    var oObject = db.Categories.Find(categoryId);
                    if (oObject != null)
                    {
                        oObject.dlt = 1;
                        oObject.OpEdit = "admin";
                        oObject.PcEdit = Environment.MachineName;
                        //oObject.DateEdit = Convert.ToString(DateTime.Now);
                        db.SaveChanges();
                        return Ok(oObject);
                    }
                    else
                    {
                        return NoContent();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

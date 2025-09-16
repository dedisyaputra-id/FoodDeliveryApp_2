using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using webapifirst.Models;

namespace webapifirst.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (var db = new FoodDeliveryContext())
                {
                   var products = db.Products
                                  .Where(d => d.dlt == 0 && d.Category.dlt == 0)
                                  .Select(p => new
                                  {
                                     p.ProductName,
                                     p.ProductId,
                                     p.ProductDescription,
                                     p.ProductPrice,
                                     p.ProductCount,
                                     p.Category.Name,
                                  }).ToList();
                   return Ok(products);
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
                using(var db = new FoodDeliveryContext())
                {
                    var product = db.Products
                                    .Include(c => c.Category)
                                    .Where(c => c.ProductId == id && c.dlt == 0 && c.Category.dlt == 0)
                                    .Select(p => new
                                    {
                                        p.ProductId,
                                        p.CategoryId,
                                        p.ProductName,
                                        p.ProductDescription,
                                        p.ProductCount,
                                        p.ProductPrice,
                                        p.Category.Name
                                    }).ToList();
                    if (product != null)
                    {
                        return Ok(product);
                    }
                    else
                    {
                        return NotFound();
                    }
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
                using (var db = new FoodDeliveryContext()) 
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                    var oObject = new Product();
                    if (string.IsNullOrEmpty(Convert.ToString(model.ProductId)))
                    {
                        oObject.ProductId = Convert.ToString(Guid.NewGuid());
                        oObject.opAdd = "admin";
                        oObject.pcAdd= Environment.MachineName;
                        oObject.dateAdd = DateTime.Now;
                        oObject.dlt = 0;
                        db.Products.Add(oObject);
                    }
                    else
                    {
                        oObject = db.Products.Find(Convert.ToString(model.ProductId));
                        if(oObject != null)
                        {
                            oObject.opEdit = "admin";
                            oObject.pcEdit= Environment.MachineName;
                            oObject.dateEdit = DateTime.Now;
                        }
                    }
                    if(oObject != null)
                    {
                        oObject.ProductName = model.ProductName;
                        oObject.ProductDescription = model.ProductDescription;
                        oObject.ProductPrice = Convert.ToInt32(model.ProductPrice);
                        oObject.ProductCount = Convert.ToInt32(model.ProductCount);
                        oObject.CategoryId = Convert.ToString(model.CategoryId);
                    }
                    db.SaveChanges();
                    var product = db.Products
                                  .Include(c => c.Category)
                                  .Where(d => d.dlt == 0 && d.Category.dlt == 0 && d.ProductId == oObject.ProductId)
                                  .Select(p => new
                                  {
                                      p.ProductName,
                                      p.ProductId,
                                      p.ProductDescription,
                                      p.ProductPrice,
                                      p.ProductCount,
                                      p.Category.Name,
                                  }).ToList();
                    return Ok(new {success = true, message = "Successfully save data" , data = product});
                }
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
                using (var db = new FoodDeliveryContext())
                {
                    var oObject = db.Products.Find(ProductId);
                    if(oObject == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        oObject.dlt = 1;
                        oObject.opEdit = "admin";
                        oObject.pcEdit = Environment.MachineName;
                        oObject.dateEdit = DateTime.Now;
                    }
                    db.SaveChanges();
                    return Ok(new { success = true, message = "Successfully delete data" });

                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

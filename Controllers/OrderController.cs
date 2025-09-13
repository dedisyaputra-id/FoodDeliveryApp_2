using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapifirst.Models;
namespace webapifirst.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        public OrderController() { }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (var db = new FoodDeliveryContext())
                {
                    var orders = db.Orders
                                   .Include(o => o.OrderDetails)
                                   .ThenInclude(o => o.product)
                                   .Where(o => o.dlt == 0)
                                   .Select(o => new
                                   {
                                       o.OrderId,
                                       o.OrderDate,
                                       o.TotalAmount,
                                       Details = o.OrderDetails.Select(d => new
                                       {
                                           d.OrderDetailId,
                                           d.OrderId,
                                           d.product.ProductName,
                                           d.product.ProductDescription,
                                           d.product.ProductPrice,
                                           d.product.ProductId,
                                           d.Quantity,
                                       })
                                   }).ToList();
                    if (orders.Any())
                    {
                        return Ok(orders);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            try
            {
                using (var db = new FoodDeliveryContext())
                {
                    var order = db.Orders
                                  .Include(o => o.OrderDetails)
                                  .ThenInclude(o => o.product)
                                  .Where(o => o.dlt == 0 && o.OrderId == id)
                                  .Select(p => new
                                  {
                                      p.OrderId,
                                      p.OrderDate,
                                      p.TotalAmount,
                                      Details = p.OrderDetails.Select(d => new
                                      {
                                          d.OrderDetailId,
                                          d.OrderId,
                                          d.product.ProductName,
                                          d.product.ProductDescription,
                                          d.product.ProductPrice,
                                          d.product.ProductId,
                                          d.Quantity,
                                      })
                                  });
                    if (order.Any())
                    {
                        return Ok(order);
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
        public IActionResult Save([FromBody] OrderDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                using (var db = new FoodDeliveryContext())
                {
                    var oObject = new Order();
                    var oObjectOrderDetail = new OrderDetail();
                    if (string.IsNullOrEmpty(model.OrderId))
                    {
                        oObject.OrderId = Convert.ToString(Guid.NewGuid());
                        oObject.OpAdd = "admin";
                        oObject.PcAdd = Environment.MachineName;
                        oObject.DateAdd = DateTime.Now;

                        db.Orders.Add(oObject);
                    }
                    else
                    {
                        oObject = db.Orders.Find(model.OrderId);
                        if(oObject != null)
                        {
                            oObject.OpAdd = "admin";
                            oObject.PcEdit = Environment.MachineName;
                        }
                    }
                    if(oObject != null)
                    {
                        oObject.OrderDate = DateTime.Now;
                        oObject.TotalAmount = model.TotalAmount;
                        oObject.OrderDetails = model.OrderDetails.Select(d => new OrderDetail
                        {
                            OrderDetailId = Convert.ToString(Guid.NewGuid()),
                            OrderId = oObject.OrderId,
                            ProductId = d.ProductId,
                            Quantity = d.Quantity,
                            OpAdd = "admin",
                            PcAdd = Environment.MachineName,
                            DateAdd = DateTime.Now,
                        }).ToList();
                    }

                    db.SaveChanges();
                    return Ok(oObject);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

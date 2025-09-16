using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapifirst.Models;
namespace webapifirst.Controllers
{
    [ApiController]
    [Authorize]
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
                                           d.SubTotal
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
                                          d.SubTotal
                                      })
                                  }).ToList();
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
                        var productIds = db.Products
                                           .Select(p => p.ProductId).ToList();
                        var products = db.Products.Where(p => productIds.Contains(p.ProductId)).ToDictionary(p => p.ProductId, p => p);

                        var orderDetails = model.OrderDetails
                                                .Select(d =>
                                                {
                                                    var product = products[d.ProductId];
                                                    var subTotal = d.Quantity * product.ProductPrice;

                                                    return new OrderDetail
                                                    {
                                                        OrderDetailId = Convert.ToString(Guid.NewGuid()),
                                                        OrderId = oObject.OrderId,
                                                        ProductId = d.ProductId,
                                                        Quantity = d.Quantity,
                                                        SubTotal = subTotal,
                                                        OpAdd = "admin",
                                                        PcAdd = Environment.MachineName,
                                                        DateAdd = DateTime.Now,
                                                    };
                                                }).ToList();
                        oObject.OrderDate = DateTime.Now;
                        oObject.TotalAmount = orderDetails.Sum(t => t.SubTotal);
                        oObject.OrderDetails = orderDetails;
                    }

                    db.SaveChanges();
                    var data = db.Orders
                                 .Include(o => o.OrderDetails)
                                 .Where(o => o.OrderId == oObject.OrderId && o.dlt == 0)
                                 .Select(p => new
                                 {
                                     p.OrderId,
                                     p.OrderDate,
                                     p.TotalAmount,
                                     Details = p.OrderDetails.Select(d => new
                                     {
                                         d.OrderDetailId,
                                         d.OrderId,
                                         d.ProductId,
                                         d.Quantity,
                                         d.product.ProductName
                                     })
                                 }).ToList();
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] string orderId)
        {
            try
            {
                if (string.IsNullOrEmpty(orderId))
                {
                    return NotFound();
                }
                using (var db = new FoodDeliveryContext())
                {
                    var order = db.Orders.Find(orderId);
                    if(order != null)
                    {
                        order.dlt = 1;
                        order.OpEdit = "admin";
                        order.PcEdit = Environment.MachineName;
                        //order.DateEdit = DateTime.Now;

                        var orderDetails = db.OrderDetails.Where(p => p.OrderId == order.OrderId).ToList();
                        if(orderDetails != null)
                        {
                            foreach(var d in orderDetails)
                            {
                                d.dlt = 1;
                                d.OpEdit = "admin";
                                d.PcEdit = Environment.MachineName;
                            }
                        }
                        db.SaveChanges();
                        return Ok(new {success = true, message = "successfully delete data"});
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
    }
}

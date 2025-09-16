using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using webapifirst.Models;

namespace webapifirst.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromForm] RegisterDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                using(var db = new FoodDeliveryContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Email.ToLower() == model.Email.ToLower() && u.dlt == 0);
                    if(user != null)
                    {
                        return Conflict(new { success = false, message = "Email is already registered, please use other email" });
                    }
                    string hashPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

                    User oObject = new User
                    {
                        UserId = Convert.ToString(Guid.NewGuid()),
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Password = hashPassword,
                        pcAdd = Environment.MachineName,
                        opAdd = "admin",
                        dateAdd = DateTime.Now
                    };
                    db.Users.Add(oObject);
                    var role = db.Roles.FirstOrDefault(r => r.Name.ToLower() == model.Role.ToLower() && r.dlt == 0);
                    if (role != null) {
                        var oObjectUserRole = new UserRole()
                        {
                            UserRoleId = Convert.ToString(Guid.NewGuid()),
                            UserId = oObject.UserId,
                            RoleId = role.Id,
                            pcAdd = Environment.MachineName,
                            opAdd = "admin",
                            dateAdd = DateTime.Now
                        };
                        db.UserRoles.Add(oObjectUserRole);
                    }
                    db.SaveChanges();
                    return Ok(new { success = true, message = "Register Successfully" });
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public IActionResult Login([FromForm] LoginDTO model)
        {
            try
            {
                using (var db = new FoodDeliveryContext())
                {
                    var user = db.Users
                                 .Where(u => u.dlt == 0 && u.Email == model.Email)
                                 .Select(u => new
                                 {
                                     u.UserId,
                                     u.Email,
                                     u.Password,
                                     u.FirstName,
                                     u.LastName,
                                     Roles = u.UserRoles.Select(r => r.Role.Name).ToList()
                                 })
                                 .FirstOrDefault();
                    if (user != null)
                    {
                        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);
                        if (!isPasswordValid)
                        {
                            return Unauthorized(new { success = false, message = "Email or password invalid" });
                        }
                    }
                    else
                    {
                        return Unauthorized(new { success = false, message = "Email or password invalid" });
                    }
                    var refreshToken = Helper.GeneratJwtToken.GenerateRefreshToken(user.UserId);
                    var accessToken = Helper.GeneratJwtToken.GenerateAccessToken(user.UserId, user.Email, user.Roles[0]);
                    Response.Cookies.Append("refreshtoken", refreshToken, new CookieOptions
                    {
                        HttpOnly = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.UtcNow.AddDays(7)
                    });
                    Response.Headers.Add("Authorization", $"Bearer {accessToken}");
                    return Ok(new {success= true, message = $"Login success, welcome {user.FirstName}", token = $"{accessToken}" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult RefreshToken()
        {
            if(!Request.Cookies.TryGetValue("refreshToken", out string refreshToken))
            {
                return Unauthorized("No refresh token found");
            }
            
            try
            {
                using(var db = new FoodDeliveryContext())
                {
                    var oObjectRefreshToken = db.RefreshTokens.FirstOrDefault(r => r.RefreshTokenSecret == refreshToken);
                    if(oObjectRefreshToken.IsRevoke == 1 || oObjectRefreshToken.ExpiresAt < DateTime.UtcNow)
                    {
                        return BadRequest("refresh token invalid");
                    }
                    var user = db.Users
                                   .Where(u => u.dlt == 0 && u.UserId == oObjectRefreshToken.userId)
                                   .Select(u => new
                                   {
                                       u.UserId,
                                       u.Email,
                                       u.Password,
                                       u.FirstName,
                                       u.LastName,
                                       Roles = u.UserRoles.Select(r => r.Role.Name).ToList()
                                   }).FirstOrDefault();
                    if (user != null)
                    {
                        var accessToken = Helper.GeneratJwtToken.GenerateAccessToken(user.UserId, user.Email, user.Roles[0]);
                        var newrefreshToken = Helper.GeneratJwtToken.GenerateRefreshToken(user.UserId);
                        Response.Cookies.Append("refreshtoken", newrefreshToken, new CookieOptions
                        {
                            HttpOnly = true,
                            SameSite = SameSiteMode.Strict,
                            Expires = DateTime.UtcNow.AddDays(7)
                        });
                        return Ok(new {accessToken = accessToken});
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}

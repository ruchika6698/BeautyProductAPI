using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommanLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        IUserBusinessLayer BusinessLayer;

        public UserController(IUserBusinessLayer BusinessDependencyInjection, IConfiguration config)
        {
            BusinessLayer = BusinessDependencyInjection;
            _config = config;
        }

        /// <summary>
        /// Method to Add User Detail
        /// </summary>
        /// <param name="Info">Register API</param>
        /// <returns> add User in database </returns>
        [HttpPost]
        public IActionResult UserRegister([FromBody] RegisterModel Info)
        {
            try
            {
                var result = BusinessLayer.UserRegister(Info);
                if (!result.Equals(null))
                {
                    var Success = "True";
                    var Message = "Registration Sucessful";
                    return this.Ok(new { Success, Message, data = Info });
                }
                else                                              //Entry is not added
                {
                    var Success = "False";
                    var Message = "Registartion Fail";
                    return this.BadRequest(new { Success, Message, data = Info });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  API for Login
        /// </summary>
        /// <param name="login"> Login API</param>
        /// <returns>Login Using username and Password</returns>
        [HttpPost]
        [Route("Login")]
        public IActionResult UserLogin(Login login)
        {
            try
            {
                UserDetails data = BusinessLayer.UserLogin(login);

                bool Success = false;
                string message;

                if (data != null)
                {
                    string JsonToken = CreateToken(data, "AuthenticateUserRole");
                    Success = true;
                    message = "Login Successfully";
                    return Ok(new { Success, message, data=data, JsonToken });
                }
                else
                {
                    message = "Enter Valid Email & Password";
                    //DATA = login;
                    return NotFound(new { Success, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Method to create JWT token
        private string CreateToken(UserDetails responseData, string type)
        {
            try
            {
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, responseData.UserRole));
                claims.Add(new Claim("EmailId", responseData.EmailId.ToString()));
                claims.Add(new Claim("Id", responseData.Id.ToString()));
                claims.Add(new Claim("TokenType", type));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signingCreds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

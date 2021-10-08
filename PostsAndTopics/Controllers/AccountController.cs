using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PostsAndTopics.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using PostsAndTopics.Dto;
using PostsAndTopics.Services.Repositories;
using System.Threading.Tasks;

namespace PostsAndTopics.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private IConfiguration _config;
        private IRepositoryWrapper _repoWrapper;

        public AccountController(IConfiguration configuration, IRepositoryWrapper repoWrapper)
        {
            _config = configuration;
            _repoWrapper = repoWrapper;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (ModelState.IsValid)
            {
                IActionResult response = Unauthorized();
                var currentUser = _repoWrapper.User.FindByCondition(u => u.UserName == dto.userName && u.Password == dto.password).FirstOrDefault();

                if (currentUser == null)
                    return response;
                else
                {
                    var tokenStr = GenerateJSONWebToken(currentUser);
                    response = Ok(new { token = tokenStr });
                }
                return response;
            }

            return View(dto);
        }

        //[HttpPost]
        //public IActionResult Login(LoginDto dto)
        //{
        //    IActionResult response = Unauthorized();

        //    //var user = AuthenticateUser(dto);
        //    var currentUser = _repoWrapper.User.FindByCondition(u => u.UserName == dto.userName && u.Password==dto.password).FirstOrDefault();

        //    if (currentUser == null)
        //        return response;
        //    else
        //    {
        //        var tokenStr = GenerateJSONWebToken(currentUser);
        //        response = Ok(new { token = tokenStr });
        //    }

        //    //if (user != null)
        //    //{
        //    //    var tokenStr = GenerateJSONWebToken(user);
        //    //    response = Ok(new { token = tokenStr });
        //    //}


        //    return response;
        //}

        private User AuthenticateUser(LoginDto login)
        {
            User user = null;
            if(login.userName =="name" && login.password == "123")
            {
                user = new User { UserName = "Name", Password = "123" };
            }
            return user;

        }

        private string GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                //new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodetoken;
        }

        [Authorize]
        [HttpPost("Post")]
        public string Post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var userName = claim[0].Value;

            return "Welcome " + userName;
        }

        [Authorize]
        [HttpGet("GetValue")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Value1", "Value2" };
        }
    }
}

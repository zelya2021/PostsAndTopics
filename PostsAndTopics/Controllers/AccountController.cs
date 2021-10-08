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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace PostsAndTopics.Controllers
{
    //[Route("api/[controller]")]
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

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, dto.userName)
                };
                var identity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();

                return RedirectToAction("Index", "Users");
            }
            return View(dto);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }`
    }
}

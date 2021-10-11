using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Security.Claims;
using PostsAndTopics.Dto;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using PostsAndTopics.Services.Interfaces;

namespace PostsAndTopics.Controllers
{
    public class AccountController : Controller
    {
        private IConfiguration _config;
        private IAccountService _accountService;

        public AccountController(IConfiguration configuration, IAccountService accountService)
        {
            _config = configuration;
            _accountService = accountService;


        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if(ModelState.IsValid)
            {
                IActionResult response = Unauthorized();

                if (_accountService.AccountActiveAsync(dto).Result == null)
                    return View();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, dto.userName)
                };

                var identity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();

                return RedirectToAction("ViewTopic", "Topics");
            }
            return View(dto);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Services.Identity.API.Models;
using Services.Identity.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Identity.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginService<ApplicationUser> _loginService;

        public AccountController(
            ILoginService<ApplicationUser> loginService)
        {
            _loginService = loginService;
        }

        public async Task<IActionResult> Login(string returnUrl)
        {
            var context = 
        }
    }
}

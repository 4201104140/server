using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.Identity.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Identity.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly IRedirectService _redirectSvc;

        public HomeController(IOptionsSnapshot<AppSettings> settings, IRedirectService redirectSvc) 
        {
            _settings = settings;
            _redirectSvc = redirectSvc;
        }

        public IActionResult Index(string returnUrl)
        {
            return View();
        }
    }
}

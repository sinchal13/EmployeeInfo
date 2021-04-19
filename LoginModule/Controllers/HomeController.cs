using LoginModule.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace LoginModule.Controllers
{
    public class HomeController : Controller

    {
        db dbl = new db();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind] Login ad)
        {
            int res = dbl.LoginCheck(ad);
            if (res == 1)
            {
                
                return RedirectToAction("Index", "Main");
            }
            else
            {
                TempData["msg"] = "UserName or Password is wrong.!";
            }
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
           
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

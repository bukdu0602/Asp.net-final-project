using ASP.NET_Final_Assignment.Data;
using ASP.NET_Final_Assignment.Models;
using ASP.NET_Final_Assignment.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Final_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //[Authorize]
        public IActionResult Index()
        {
            var email = User.Identity.Name;
            if (email != null)
            {
                AccountRepo accountRepository = new AccountRepo(_context);
                var nameSession = accountRepository.getNameSession(User.Identity.Name);

                if (HttpContext.Session.GetString("nameKey") == null)
                {
                    HttpContext.Session.SetString("nameKey", nameSession.firstName);
                }
                else
                {
                    HttpContext.Session.SetString("nameKey", nameSession.firstName);
                }
                ViewBag.Name = HttpContext.Session.GetString("nameKey");
            }
            return View();
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

using ASP.NET_Final_Assignment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Final_Assignment.Controllers
{
    public class AccountsController1 : Controller
    {
        private ApplicationDbContext _context;

        public AccountsController1(ApplicationDbContext context, ILogger<AccountsController1> logger)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Clients);
        }
    }
}

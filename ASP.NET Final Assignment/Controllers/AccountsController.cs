using ASP.NET_Final_Assignment.Data;
using ASP.NET_Final_Assignment.Repositories;
using ASP.NET_Final_Assignment.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Final_Assignment.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccountsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
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
            AccountRepo accountRepo = new AccountRepo(_context);
            var query = accountRepo.GetList( User.Identity.Name);

            return View(query);
        }
        [Authorize]
        public IActionResult Details(int clientID, int accountNum)
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
            AccountRepo accountRepo = new AccountRepo(_context);
            var detailQuery = accountRepo.GetDetail(clientID, accountNum);
            return View(detailQuery);
        }
        [Authorize]
        public IActionResult Edit(int? clientID, int? accountNum)
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
            AccountRepo accountRepo = new AccountRepo(_context);
            var editQuery = accountRepo.GetEdit(clientID, accountNum);
            
            return View(editQuery);
        }

        [HttpPost]
        public IActionResult Edit(
    [Bind("clientID,lastName,firstName, accountNum, balance")] AccountDetailsVM accountDetailsVM)
        {
            
                AccountRepo accountRepo = new AccountRepo(_context);
                accountRepo.Update(accountDetailsVM);
            
            return RedirectToAction("Index", "Accounts");
        }

        public IActionResult Create()
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
            ViewData["accountType"] = new SelectList(_context.BankAccounts, "accountType", "accountType");
            return View();
        }

        [HttpPost]
        public IActionResult Create(
            [Bind( "balance, accountType")] AccountDetailsVM accountDetailsVM)
        {
            
                AccountRepo accountRepo = new AccountRepo(_context);
                accountRepo.Create(accountDetailsVM, User.Identity.Name);
            
            return RedirectToAction("Index", "Accounts");
        }

        public IActionResult Delete(int? clientID, int? accountNum)
        {
            AccountRepo accountRepo = new AccountRepo(_context);
            var deleteQuery = accountRepo.DeleteTable(clientID, accountNum);
            return RedirectToAction("Index", "Accounts");
        }



    }
}

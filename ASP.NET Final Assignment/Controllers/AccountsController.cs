using ASP.NET_Final_Assignment.Data;
using ASP.NET_Final_Assignment.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            //var query = from c in _context.Clients
            //            from b in _context.BankAccounts
            //            where (c.clientID == b.accountNum)
            //            select new AccountDetailsVM()
            //            {
            //                clientID = (c.clientID != null) ? c.clientID : 0,
            //                lastName = (c.lastName != null) ? c.lastName : "",
            //                firstName = (c.firstName != null) ? c.firstName : "",
            //                email = (c.email != null) ? c.email : "",
            //                accountNum = (b.accountNum != null) ? b.accountNum : 0,
            //                accountType = (b.accountType != null) ? b.accountType : "",
            //                balance = (b.balance != null) ? b.balance : 0,
            //            };


            var query = from c in _context.Clients
                        from nav in c.ClientAccount
                        from b in _context.BankAccounts
                        from nav2 in b.ClientAccount
                        where (nav.accountNum == nav2.accountNum && nav.clientID == nav2.clientID)
                        select new AccountDetailsVM()
                        {
                            clientID = (c.clientID != null) ? c.clientID : 0,
                            lastName = (c.lastName != null) ? c.lastName : "",
                            firstName = (c.firstName != null) ? c.firstName : "",
                            email = (c.email != null) ? c.email : "",
                            accountNum = (b.accountNum != null) ? b.accountNum : 0,
                            accountType = (b.accountType != null) ? b.accountType : "",
                            balance = (b.balance != null) ? b.balance : 0,
                        };

            return View(query);
        }
        [Authorize]
        public IActionResult Details(int id)
        {
            var detailQuery = (from c in _context.Clients
                               from nav in c.ClientAccount
                               from b in _context.BankAccounts
                               from nav2 in b.ClientAccount
                               where (id == c.clientID && nav.accountNum == nav2.accountNum && nav.clientID == nav2.clientID)
                               select new AccountDetailsVM()
                               {
                                   clientID = (c.clientID != null) ? c.clientID : 0,
                                   lastName = (c.lastName != null) ? c.lastName : "",
                                   firstName = (c.firstName != null) ? c.firstName : "",
                                   email = (c.email != null) ? c.email : "",
                                   accountNum = (b.accountNum != null) ? b.accountNum : 0,
                                   accountType = (b.accountType != null) ? b.accountType : "",
                                   balance = (b.balance != null) ? b.balance : 0,
                               }).FirstOrDefault();
            return View(detailQuery);
        }
        [Authorize]
        public IActionResult Edit(int? id)
        {
            var editQuery = (from c in _context.Clients
                               from nav in c.ClientAccount
                               from b in _context.BankAccounts
                               from nav2 in b.ClientAccount
                               where (id == c.clientID && nav.accountNum == nav2.accountNum && nav.clientID == nav2.clientID)
                               select new AccountDetailsVM()
                               {
                                   clientID = (c.clientID != null) ? c.clientID : 0,
                                   lastName = (c.lastName != null) ? c.lastName : "",
                                   firstName = (c.firstName != null) ? c.firstName : "",
                                   email = (c.email != null) ? c.email : "",
                                   accountNum = (b.accountNum != null) ? b.accountNum : 0,
                                   accountType = (b.accountType != null) ? b.accountType : "",
                                   balance = (b.balance != null) ? b.balance : 0,
                               }).FirstOrDefault();
            return View(editQuery);
        }

    }
}

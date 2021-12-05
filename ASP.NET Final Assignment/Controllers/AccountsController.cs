using ASP.NET_Final_Assignment.Data;
using ASP.NET_Final_Assignment.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Final_Assignment.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var query = from c in context.Clients
                        from b in context.BankAccounts
                        where (c.clientID == b.accountNum)
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


            //var query = from c in context.Clients
            //            from nav in c.ClientAccount
            //            from b in context.BankAccounts
            //            from nav2 in b.ClientAccount
            //            where (nav.accountNum == nav2.accountNum && nav.clientID == nav2.clientID)
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

            return View(query);
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}

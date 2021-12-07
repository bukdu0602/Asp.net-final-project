using ASP.NET_Final_Assignment.Data;
using ASP.NET_Final_Assignment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Final_Assignment.Repositories
{
    public class AccountRepo
    {
        private readonly ApplicationDbContext _context;

        public AccountRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Update(AccountDetailsVM accountDetailsVM)
        {
            var editQuery = (from c in _context.Clients
                             where accountDetailsVM.clientID == c.clientID
                             select c
                             ).FirstOrDefault();

            var editQuery2 = (from b in _context.BankAccounts
                             where accountDetailsVM.accountNum == b.accountNum
                             select b
                             ).FirstOrDefault();


            editQuery.lastName = accountDetailsVM.lastName;
            editQuery.firstName = accountDetailsVM.firstName;
            editQuery2.balance = accountDetailsVM.balance;
            _context.SaveChanges();

            return true;
        }

        public AccountDetailsVM GetEdit(int? id, int? aNum)
        {
            var editQuery = (from c in _context.Clients
                             from b in _context.BankAccounts
                             where (id == c.clientID && aNum == b.accountNum)
                             select new AccountDetailsVM()
                             {
                                 clientID = c.clientID,
                                 lastName = (c.lastName != null) ? c.lastName : "",
                                 firstName = (c.firstName != null) ? c.firstName : "",
                                 email = (c.email != null) ? c.email : "",
                                 accountNum = b.accountNum,
                                 accountType = (b.accountType != null) ? b.accountType : "",
                                 balance = b.balance,
                             }).FirstOrDefault();
            return editQuery;
        }

        public AccountDetailsVM GetDetail(int? id, int? aNum)
        {
            var detailQuery = (from c in _context.Clients
                               from b in _context.BankAccounts
                               where (id == c.clientID && aNum == b.accountNum )
                               select new AccountDetailsVM()
                               {
                                   clientID = c.clientID,
                                   lastName = (c.lastName != null) ? c.lastName : "",
                                   firstName = (c.firstName != null) ? c.firstName : "",
                                   email = (c.email != null) ? c.email : "",
                                   accountNum = b.accountNum,
                                   accountType = (b.accountType != null) ? b.accountType : "",
                                   balance = b.balance,
                               }).FirstOrDefault();
            return detailQuery;
        }
        public IQueryable GetList(string email)
        {
            var query = from c in _context.Clients
                        from nav in c.ClientAccount
                        from b in _context.BankAccounts
                        from nav2 in b.ClientAccount
                        where (c.email == email && c.clientID == nav.clientID && nav.accountNum == b.accountNum)
                        select new AccountDetailsVM()
                        {
                            clientID = c.clientID,
                            lastName = (c.lastName != null) ? c.lastName : "",
                            firstName = (c.firstName != null) ? c.firstName : "",
                            email = (c.email != null) ? c.email : "",
                            accountNum = b.accountNum,
                            accountType = (b.accountType != null) ? b.accountType : "",
                            balance = b.balance,
                        };
            return query;
        }

        public bool Create(AccountDetailsVM accountDetailsVM, string email)
        {
            var query = (from c in _context.Clients
                         where (c.email == email)
                         select c).FirstOrDefault();
            BankAccount bankAccount = new BankAccount()
            {
                accountType = accountDetailsVM.accountType,
                balance = accountDetailsVM.balance
            };
            _context.Add(bankAccount);
            _context.SaveChanges();
            ClientAccount clientAccount = new ClientAccount()
            {
                accountNum = bankAccount.accountNum,
                clientID = query.clientID
            };
            _context.Add(clientAccount);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteTable(int? clientID, int? accountNum)
        {
            string deleteMessage = "Product Id: " + clientID
                                 + " deleted successfully";
            try
            {
                var clientAccount = (from ca in _context.ClientAccounts
                                     where ca.clientID == clientID && ca.accountNum == accountNum
                                     select ca).FirstOrDefault();

                var bAccount = (from b in _context.BankAccounts
                                where b.accountNum == accountNum
                                select b).FirstOrDefault();

                _context.Remove(clientAccount);
                _context.Remove(bAccount);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                deleteMessage = e.Message + " "
                + "The product may not exist or "
                + "there could be a foreign key restriction.";
            }
            return true;
        }

    }
}

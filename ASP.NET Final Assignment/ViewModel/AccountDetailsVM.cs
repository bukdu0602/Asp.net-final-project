using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Final_Assignment.ViewModel
{
    public class AccountDetailsVM
    {
        [DisplayName("Client Number")]
        public int clientID { get; set; }
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Account Number")]
        public int accountNum { get; set; }
        [DisplayName("Account Type")]
        public string accountType { get; set; }
        [DisplayName("Balance")]
        public decimal balance { get; set; }
    }
}

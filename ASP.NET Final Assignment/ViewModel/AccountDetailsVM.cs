using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Final_Assignment.ViewModel
{
    public class AccountDetailsVM
    {
        [DisplayName("Client Number")]
        public int clientID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]{1,50}$")]
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]{1,50}$")]
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Account Number")]
        public int accountNum { get; set; }
        [Required]
        [DisplayName("Account Type")]
        public string accountType { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [DataType(DataType.Currency)]
        [DisplayName("Balance")]
        public decimal balance { get; set; }
    }
}

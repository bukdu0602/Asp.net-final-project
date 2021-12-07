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
        [StringLength(50, ErrorMessage = "Name must be maximum of 50 characters.")]
        [DataType(DataType.Text)]
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name must be maximum of 50 characters.")]
        [DataType(DataType.Text)]
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
        [DataType(DataType.Currency)]
        [DisplayName("Balance")]
        public decimal balance { get; set; }
    }
}

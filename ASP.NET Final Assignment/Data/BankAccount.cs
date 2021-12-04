using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static ASP.NET_Final_Assignment.Data.ApplicationDbContext;

namespace ASP.NET_Final_Assignment.Data
{
    public class BankAccount
    {
        [Key]
        public int accountNum { get; set; }
        public string accountType { get; set; }
        public string balance { get; set; }

        public virtual ICollection<ClientAccount>
            ClientAccount
        { get; set; }
    }
}

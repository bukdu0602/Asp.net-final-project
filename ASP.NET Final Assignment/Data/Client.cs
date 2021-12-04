using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static ASP.NET_Final_Assignment.Data.ApplicationDbContext;

namespace ASP.NET_Final_Assignment.Data
{
    public class Client
    {
        [Key]
        public int clientID { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string email { get; set; }

        public virtual ICollection<ClientAccount>
            ClientAccount
        { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ASP.NET_Final_Assignment.Data
{

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //------------------------------------------
        public DbSet<Client> Clients { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<ClientAccount> ClientAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define composite primary keys.
            modelBuilder.Entity<ClientAccount>()
                .HasKey(ps => new { ps.clientID, ps.accountNum });

            // Define foreign keys here. Do not use foreign key annotations.
            modelBuilder.Entity<ClientAccount>()
                .HasOne(p => p.Client)
                .WithMany(p => p.ClientAccount)
                .HasForeignKey(fk => new { fk.clientID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<ClientAccount>()
                .HasOne(p => p.BankAccount)
                .WithMany(p => p.ClientAccount)
                .HasForeignKey(fk => new { fk.accountNum })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
        }

        public class Client
        {
            [Key]
            public int clientID { get; set; }
            public string lastName { get; set; }
            public string firstName { get; set; }
            public string email { get; set; }
      
            public virtual ICollection<ClientAccount>
                ClientAccount { get; set; }
        }

        public class BankAccount
        {
            [Key]
            public int accountNum { get; set; }
            public string accountType { get; set; }
            public string balance { get; set; }

            public virtual ICollection<ClientAccount>
                ClientAccount { get; set; }
        }

        public class ClientAccount
        {
            [Key, Column(Order = 0)]
            public int clientID { get; set; }
            [Key, Column(Order = 1)]
            public int accountNum { get; set; }

            public virtual Client Client { get; set; }
            public virtual BankAccount BankAccount { get; set; }
        }
    }



    ///------------------------------------------


}

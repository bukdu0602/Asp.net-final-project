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
        public ApplicationDbContext()
        {
        }

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
            base.OnModelCreating(modelBuilder);
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

            //modelBuilder.Entity<Client>().HasData(
            //     new Client { clientID = 1, lastName = "Cam", firstName = "Charlene", email = "cam@home.com" },
            //new Client { clientID = 2, lastName = "Choi", firstName = "Calvin", email = "choi@home.com" },
            //new Client { clientID = 3, lastName = "Craig", firstName = "Carly", email = "craig@home.com" });

            //modelBuilder.Entity<BankAccount>().HasData(
            //    new BankAccount { accountNum = 1, accountType = "Chequing", balance = "1000" },
            //    new BankAccount { accountNum = 2, accountType = "Saving", balance = "2000" },
            //    new BankAccount { accountNum = 3, accountType = "Chequing", balance = "3000" });

            //modelBuilder.Entity<ClientAccount>().HasData(
            //    new ClientAccount { clientID = 1, accountNum = 1 },
            //    new ClientAccount { clientID = 2, accountNum = 2 },
            //    new ClientAccount { clientID = 3, accountNum = 3 });

        }

        //public class Client
        //{
        //    [Key]
        //    public int clientID { get; set; }
        //    public string lastName { get; set; }
        //    public string firstName { get; set; }
        //    public string email { get; set; }

        //    public virtual ICollection<ClientAccount>
        //        ClientAccount
        //    { get; set; }
        //}

        //public class BankAccount
        //{
        //    [Key]
        //    public int accountNum { get; set; }
        //    public string accountType { get; set; }
        //    public string balance { get; set; }

        //    public virtual ICollection<ClientAccount>
        //        ClientAccount
        //    { get; set; }
        //}

        //public class ClientAccount
        //{
        //    [Key, Column(Order = 0)]
        //    public int clientID { get; set; }
        //    [Key, Column(Order = 1)]
        //    public int accountNum { get; set; }

        //    public virtual Client Client { get; set; }
        //    public virtual BankAccount BankAccount { get; set; }
        //}
    }
    ///------------------------------------------





}

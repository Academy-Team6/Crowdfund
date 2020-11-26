using Crowdfund.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Data
{
    public class CrowdfundDbContext: DbContext
    {
        public DbSet<ProjectCreator> ProjectCreators { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<RewardPackage> RewardPackages { get; set; }
        public DbSet<Backer> Backers { get; set; }
        public DbSet<TransactionPackage> TransactionPackages { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Media> Media { get; set; }
        public readonly static string connectionString = "Server =localhost; " +
           "Database =fund2; " +
           "User Id =sa; " +
           "Password =admin!@#123;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=tcp:crowdfund.database.windows.net,1433;Initial Catalog=CrowdfundDb;Persist Security Info=False;User ID=pmarouga;Password=Latsio12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Backer>();
            modelBuilder.Entity<Project>();
            modelBuilder.Entity<ProjectCreator>();
            modelBuilder.Entity<RewardPackage>();
            modelBuilder.Entity<Media>();
            modelBuilder.Entity<Transaction>();
            modelBuilder.Entity<TransactionPackage>();

        }
    }
}

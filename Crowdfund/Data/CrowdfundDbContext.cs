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
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =localhost; " +
            "Database =fund; " +
            "User Id =sa; " +
            "Password =admin!@#123;");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Backer>();
        //    modelBuilder.Entity<Project>();
        //    modelBuilder.Entity<ProjectCreator>();
        //    modelBuilder.Entity<RewardPackage>();
        //    modelBuilder.Entity<Media>();
        //    modelBuilder.Entity<ProjectPackage>();
        //    modelBuilder.Entity<Transaction>();
        //    modelBuilder.Entity<TransactionPackage>();

        //}
        public CrowdfundDbContext(DbContextOptions<CrowdfundDbContext> options)
              : base(options)
        { }
        public CrowdfundDbContext()
        { }

    }
}

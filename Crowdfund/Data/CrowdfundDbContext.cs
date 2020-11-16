using Crowdfund.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Data
{
    class CrowdfundDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:crowdfund.database.windows.net,1433;Initial Catalog=Crowdfund;Persist Security Info=False;User ID=pmarouga;Password=Latsio12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Backer>();
            modelBuilder.Entity<Project>();
            modelBuilder.Entity<ProjectCreator>();
            modelBuilder.Entity<RewardPackage>();
            modelBuilder.Entity<Media>();
        }
    }
}

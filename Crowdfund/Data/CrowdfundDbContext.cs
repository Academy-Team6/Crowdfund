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
            optionsBuilder.UseSqlServer("connection string");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Backer>();
            modelBuilder.Entity<Project>();
            modelBuilder.Entity<ProjectCreator>();
            modelBuilder.Entity<RewardPackage>();

            //How to use the entities without declaring DbSet
            //
            //using var db = new CrowdfundDbContext();
            //var Backer=db.Set<Backer>().Find(Id);
            
            //How to make Table for Joints
            //
            // works on EF Core 5.0
            //modelBuilder.Entity<Order>().HasMany(o => o.Products);

            // Many-to-many: works on EF Core 3.x
            //modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.OrderId, op.ProductId });


            //If we need to use Required for some property
            /*
                    modelBuilder.Entity<Customer>()
                        .Property(c => c.FirstName).
                        IsRequired();

                    modelBuilder.Entity<Customer>()
                        .Property(c => c.LastName)
                        .IsRequired();
            */

        }
    }
}

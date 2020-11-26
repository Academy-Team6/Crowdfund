using Crowdfund.API;
using Crowdfund.Data;
using Crowdfund.model;
using Crowdfund.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crowdfund.Services
{
    public class BackerServices : IBackerService
    {
        private readonly CrowdfundDbContext dbContext;
        public BackerServices(CrowdfundDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public BackerOption CreateBacker(BackerOption backerOption)
        {
            Backer backer = new Backer
            {
                Name = backerOption.Name,
                Email = backerOption.Email
            };

            dbContext.Backers.Add(backer);
            dbContext.SaveChanges();
            return new BackerOption
            {
                Name = backer.Name,
                Email = backer.Email
            };
        }

        public bool DeleteBacker(int id)
        {
            Backer backer = dbContext.Backers.Find(id);
            if (backer == null) return false;
            dbContext.Backers.Remove(backer);
            dbContext.SaveChanges();
            return true;

        }

        public BackerOption FindBacker(int id)
        {
            Backer backer = dbContext.Backers.Find(id);
            return new BackerOption
            {
                Name = backer.Name,
                Email = backer.Email,
                Id = backer.Id // might need fixing
            };
        }
        private static void BackerOptToBacker(BackerOption backerOpt, Backer backer)
        {
            backer.Name = backerOpt.Name;
            backer.Email = backerOpt.Email;
        }

        public BackerOption UpdateBacker(int id, BackerOption backerOption)
        {

            Backer backer = dbContext.Backers.Find(id);
            BackerOptToBacker(backerOption, backer);
            dbContext.SaveChanges();

            return new BackerOption
            {
                Name = backer.Name,
                Email = backer.Email
            };
        }
        public List<BackerOption> GetAllBackers()
        {
            List<Backer> backers = dbContext.Backers.ToList();
            List<BackerOption> backerOpt = new List<BackerOption>();
            backers.ForEach(backer => backerOpt.Add(new BackerOption
            {
                Name = backer.Name,
                Email = backer.Email,
                Id = backer.Id //something is wrong ?
            }));

            return backerOpt;
        }
        public List<BackerOption> SearchBackers(string searchCriteria)
        {
            List<Backer> backers = dbContext.Backers
                .Where(backer => backer.Name.Contains(searchCriteria)
               || backer.Email.Contains(searchCriteria)
                )
                .ToList();

            List<BackerOption> backerOpt = new List<BackerOption>();
            backers.ForEach(backer => backerOpt.Add(new BackerOption
            {
                Name = backer.Name,
                Email = backer.Email,
                Id = backer.Id //something is wrong ?
            }));

            return backerOpt;
        }
    }
}
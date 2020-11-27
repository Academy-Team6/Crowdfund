using Crowdfund.API;
using Crowdfund.Data;
using Crowdfund.model;
using Crowdfund.Options;
using System.Collections.Generic;
using System.Linq;

namespace Crowdfund.Services
{
    public class RewardPackageServices : IRewardPackageService
    {
        private readonly CrowdfundDbContext dbContext = new CrowdfundDbContext();
        private static RewardPackage GetRewardPackageFromRewardPackageOption(RewardPackageOption rewardPackageOption)
        {
            return new RewardPackage
            {
                Reward = rewardPackageOption.Reward,
                Price = rewardPackageOption.Price,
               
            };
        }
        public RewardPackageOption CreateRewardPackage(RewardPackageOption rewardPackageOption)
        {
            RewardPackage rewardPackage = GetRewardPackageFromRewardPackageOption(rewardPackageOption);

            dbContext.RewardPackages.Add(rewardPackage);
            dbContext.SaveChanges();
            rewardPackageOption.Id = rewardPackage.Id;
            return rewardPackageOption;
        }

        public bool DeleteRewardPackage(int id)
        {
            RewardPackage rp = dbContext.RewardPackages.Find(id);
            if (rp == null) return false;
            dbContext.RewardPackages.Remove(rp);
            dbContext.SaveChanges();
            return true;
        }

        private static RewardPackageOption GetRewardPackageOptionsFromRewardPackage(RewardPackage rewardPackage)
        {
            return new RewardPackageOption
            {
                Reward = rewardPackage.Reward,
                Price = rewardPackage.Price,
                Id = rewardPackage.Id
            };
        }
        public List<RewardPackageOption> GetAllRewardPackages()
        {
            List<RewardPackage> rewardPackages = dbContext.RewardPackages.ToList();
            List<RewardPackageOption> rewardPackageOptions = new List<RewardPackageOption>();
            rewardPackages.ForEach(rewardPackage => rewardPackageOptions.Add(
                    GetRewardPackageOptionsFromRewardPackage(rewardPackage)
            ));
            return rewardPackageOptions;
        }
        public RewardPackageOption FindRewardPackageById(int id)
        {
            RewardPackage rewardPackage = dbContext.RewardPackages.Find(id);
            if (rewardPackage == null) return null;
            return GetRewardPackageOptionsFromRewardPackage(rewardPackage);
        }

        public RewardPackageOption UpdateRewardPackage(int id, RewardPackageOption rewardPackageOption)
        {
            RewardPackage rewardPackage = dbContext.RewardPackages.Find(id);
            rewardPackage.Reward = rewardPackageOption.Reward;
            rewardPackage.Price = rewardPackageOption.Price;
            dbContext.SaveChanges();

            return rewardPackageOption;
        }

        public RewardPackageOption GetRewardPackage(int id)
        {
            return FindRewardPackageById(id);
        }
    }
}

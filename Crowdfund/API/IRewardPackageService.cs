using Crowdfund.Options;

namespace Crowdfund.API
{
    interface IRewardPackageService
    {
        public RewardPackageOption CreateRewardPackage(RewardPackageOption rewardPackageOption);
        public RewardPackageOption FindRewardPackage(int id);
        public RewardPackageOption UpdateRewardPackage(int id, RewardPackageOption rewardPackageOption);
        public bool DeleteRewardPackage(int id);
    }
}

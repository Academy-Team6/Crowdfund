using Crowdfund.Options;

namespace Crowdfund.API
{
    public interface IBackerService
    {
        public BackerOption CreateBacker(BackerOption backerOption);
        public BackerOption FindBacker(int id);
        public BackerOption UpdateBacker(int id, BackerOption backerOption);
        public bool DeleteBacker(int id);
        public RewardPackageOption BuyPackage(int BackerId,int RewardPackageId);
    }
}
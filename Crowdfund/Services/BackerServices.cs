using Crowdfund.API;
using Crowdfund.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Services
{
    public class BackerServices : IBackerService
    {
        public RewardPackageOption BuyPackage(int BackerId, int RewardPackageId)
        {
            throw new NotImplementedException();
        }

        public BackerOption CreateBacker(BackerOption backerOption)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBacker(int id)
        {
            throw new NotImplementedException();
        }

        public BackerOption FindBacker(int id)
        {
            throw new NotImplementedException();
        }

        public BackerOption UpdateBacker(int id, BackerOption backerOption)
        {
            throw new NotImplementedException();
        }
    }
}

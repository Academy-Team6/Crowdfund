using Crowdfund.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundWebApp.Models
{
    public class RewardPackageModel
    {
        public List<RewardPackageOption> RewardPackages { get; set; }
    }

    public class RewardPackageOptionModel
    {
        public RewardPackageOption RewardPackage { get; set; }
    }
}

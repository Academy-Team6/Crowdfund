using Crowdfund.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundWebApp.Models
{
    public class TransactionModel
    {
        public List<RewardPackageOption> rewardpackages { get; set; }
        public int transactionId { get; set; }
    }
}

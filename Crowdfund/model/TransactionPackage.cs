using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.model
{
    public class TransactionPackage
    {
            public int Id { get; set; }
            public RewardPackage RewardPackage { get; set; }
            public Transaction Transaction { get; set; } 
    }
}

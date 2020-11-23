using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.model
{
    public class Transaction
    {
        public int Id { get; set; }
        public Backer Backer { get; set; }
        public List<TransactionPackage> TransactionPackages { get; set; }
        public decimal Amount { get; set; }
        //public Project Project { get; set; }
        //public RewardPackage TransactionPackage { get; set; }
        //public decimal Amount { get; set; }
    }
}

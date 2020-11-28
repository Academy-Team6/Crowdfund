using Crowdfund.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundWebApp.Models
{
    public class TransactionModel
    {
        public List<TransactionOption> Transactions { get; set; }
    }
    public class TransactionOptionModel
    {
        public TransactionOption Transaction { get; set; }
    }
}

using Crowdfund.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.API
{
    public interface ITransactionService
    {
        TransactionOption CreateTransaction(BackerOption backer);
        TransactionOption AddRewardPackageToTransaction(int transactionId, int rewardpackageId);
        TransactionOption GetTransaction(int transactionId);
    }
}

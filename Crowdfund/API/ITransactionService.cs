using Crowdfund.Options;
using System.Collections.Generic;

namespace Crowdfund.API
{
    public interface ITransactionService
    {
        TransactionOption CreateTransaction(BackerOption backer);
        TransactionOption FindTransactionById(int id);
        TransactionOption AddRewardPackageToTransaction(int transactionId, int rewardpackageId);
        List<TransactionOption> GetAllTransactions(); 
        TransactionOption GetTransaction(int transactionId);
    }
}

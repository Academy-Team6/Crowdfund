using Crowdfund.Options;
using System.Collections.Generic;

namespace Crowdfund.API
{
    public interface ITransactionService
    {
        TransactionOption CreateTransaction(int backerId, int rewardPackageOptionId);
        TransactionOption FindTransactionById(int id);
      // RewardPackageOption AddRewardPackageToTransaction(int rewardpackageId);
        List<TransactionOption> GetAllTransactions();
        List<TransactionOption> GetMyTransactions(int backerId);
        TransactionOption GetTransaction(int transactionId);
        List<TransactionOption> BackedProjects(int backerId);
    }
}

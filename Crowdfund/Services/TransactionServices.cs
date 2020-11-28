using Crowdfund.API;
using Crowdfund.Data;
using Crowdfund.model;
using Crowdfund.Options;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Crowdfund.Services
{
    public class TransactionServices : ITransactionService
    {
        private readonly CrowdfundDbContext dbContext = new CrowdfundDbContext();
        public TransactionOption CreateTransaction(int backerId , int rewardPackageOptionId)
        {
            if (backerId == 0 ) return null;
            Backer backer = dbContext.Backers.Find(backerId);
            if (backer == null) return null;
            Transaction transaction = new Transaction { Backer = backer };
            dbContext.Transactions.Add(transaction);
            dbContext.SaveChanges();
            TransactionOption transactionOption = new TransactionOption
            {
                BackerName = backer.LastName +" "+ backer.FirstName +" ",
                TransactionId = transaction.Id,
                BackerId = backer.Id,
                RewardPackages = AddRewardPackageToTransaction(rewardPackageOptionId)
            };
            return transactionOption;
        }

        public TransactionOption GetTransaction(int transactionId)
        {
            Transaction transaction = dbContext.Transactions.Include(o => o.Backer).FirstOrDefault(x => x.Id == transactionId);
            Backer backer = dbContext.Backers.Find(transaction.Backer.Id);

            List<int> rewardpackages = new List<int>();
            List<TransactionPackage> tranactionPackages = dbContext.TransactionPackages
                .Include(rp => rp.RewardPackage)
                .Where(rp => rp.Transaction.Equals(transaction)).ToList();

            tranactionPackages.ForEach(rp => rewardpackages.Add(rp.RewardPackage.Id));

            TransactionOption transactionOption = new TransactionOption
            {
                BackerName = backer.LastName+ " "+ backer.FirstName + " ",
                TransactionId = transaction.Id

                //ProjectId     = project.Id,
                //RewardPackages = rewardpackages
            };

            return transactionOption;
        }

        public RewardPackageOption AddRewardPackageToTransaction(int rewardPackageId)
        {
            RewardPackage rewardPackage = dbContext.RewardPackages.Find(rewardPackageId);
            RewardPackageOption rewardPackageOption = new RewardPackageOption
            {
                Id = rewardPackage.Id,
                Price =rewardPackage.Price,
                Reward = rewardPackage.Reward,
                ProjectId = rewardPackage.Project.Id
            };
            return rewardPackageOption;
        }

        public TransactionOption FindTransactionById(int id)
        {
            Transaction transaction = dbContext.Transactions.Find(id);
            if (transaction == null) return null;
            List<int> Rewardpackages = new List<int>();
            return new TransactionOption
            {
                BackerName = transaction.Backer.LastName,
                TransactionId = transaction.Id
                //RewardPackages = transaction.TransactionPackages.
            };
        }

        public List<TransactionOption> GetAllTransactions()
        {
            List<Transaction> tr = dbContext.Transactions.ToList();
            List<TransactionOption> trOpt = new List<TransactionOption>();
            tr.ForEach(tr => trOpt.Add(new TransactionOption
            {
                BackerName = tr.Backer.LastName,
                TransactionId = tr.Id
                //RewardPackages = transaction.TransactionPackages.
            }));

            return trOpt;
        }


    }
}

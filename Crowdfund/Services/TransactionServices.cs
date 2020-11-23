using Crowdfund.API;
using Crowdfund.Data;
using Crowdfund.model;
using Crowdfund.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crowdfund.Services
{
    public class TransactionServices : ITransactionService
    {
        private readonly CrowdfundDbContext dbContext;
        public TransactionServices(CrowdfundDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public TransactionOption CreateTransaction(BackerOption backerOpt)
        {
            if (backerOpt == null) return null;
            Backer backer = dbContext.Backers.Find(backerOpt.Id);
            if (backer == null) return null;
            Transaction transaction = new Transaction { Backer = backer };
            dbContext.Transactions.Add(transaction);
            dbContext.SaveChanges();
            TransactionOption transactionOption = new TransactionOption
            {
                BackerName = backer.Name + " ",
                TransactionId = transaction.Id
            };
            return transactionOption;
        }

        public TransactionOption GetTransaction(int orderId)
        {
            Transaction transaction = dbContext.Transactions.Include(o => o.Backer).FirstOrDefault(x => x.Id == orderId);
            Backer backer = dbContext.Backers.Find(transaction.Backer.Id);

            List<int> rewardpackages = new List<int>();
            List<TransactionPackage> tranactionPackages = dbContext.TransactionPackages
                .Include(rp => rp.RewardPackage)
                .Where(rp => rp.Transaction.Equals(transaction)).ToList();

            tranactionPackages.ForEach(rp => rewardpackages.Add(rp.RewardPackage.Id));

            TransactionOption transactionOption = new TransactionOption
            {
                BackerName = backer.Name + " ",
                TransactionId = transaction.Id
                
                //ProjectId     = project.Id,
                //RewardPackages = rewardpackages
            };

            return transactionOption;
        }

        public TransactionOption AddRewardPackageToTransaction(int transactionId, int rewardPackageId)
        {
            Transaction transaction = dbContext.Transactions.Find(transactionId);
            RewardPackage rewardPackage = dbContext.RewardPackages.Find(rewardPackageId);
            TransactionPackage transactionPackage = new TransactionPackage
            {
                Transaction = transaction,
                RewardPackage = rewardPackage
            };
            dbContext.TransactionPackages.Add(transactionPackage);
            dbContext.SaveChanges();
            return GetTransaction(transactionId);
        }
    }
}

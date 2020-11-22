using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crowdfund.API;
using Crowdfund.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrowdfundWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public ITransactionService transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        [HttpGet("{id}")]
        public TransactionOption GetTransaction(int id)
        {
            return transactionService.GetTransaction(id);
        }

        [HttpPost]
        public TransactionOption CreateTransaction(BackerOption backerOpt)
        {
            return transactionService.CreateTransaction(backerOpt);
        }

        [HttpPost("{transactionId}/rewardpackage/{rewardpackageId}")]
        public TransactionOption AddRewardPackageToTransaction(int ordedId, int productId)
        {
            return transactionService.AddRewardPackageToTransaction(ordedId, productId);
        }
    }
}

﻿using System;
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
        private readonly ITransactionService transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        //[HttpGet]
        //public List<TransactionOption> GetAllTransactions()
        //{
        //    return transactionService.GetAllTransactions();
        //}
        [HttpGet]
        public List<TransactionOption> GetMyTransactions(int backerId)
        {
            return transactionService.GetMyTransactions(backerId);
        }
        [HttpGet("{id}")]
        public TransactionOption GetTransaction(int id)
        {
            return transactionService.GetTransaction(id);
        }
        [HttpGet("{id}")]
        public TransactionOption FindTransaction(int id)
        {
            return transactionService.FindTransactionById(id);
        }
        [HttpPost]
        public TransactionOption CreateTransaction([FromForm] TransactionOption transactionOption)
        {
            return transactionService.CreateTransaction(transactionOption.BackerId, transactionOption.RewardPackageId);
        }

        //[HttpPost("{transactionId}/rewardpackage/{rewardpackageId}")]
        //public TransactionOption AddRewardPackageToTransaction(int ordedId, int productId)
        //{
        //    return transactionService.AddRewardPackageToTransaction(ordedId, productId);
        //}
    }
}

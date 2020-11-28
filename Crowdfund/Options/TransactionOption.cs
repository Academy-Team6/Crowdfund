﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Options
{
    public class TransactionOption
    {
        public string BackerName { get; set; }
        public int BackerId { get; set; }
        public int TransactionId { get; set; }
        public int RewardPackageId { get; set; }
        public RewardPackageOption RewardPackage { get; set; }
        
    }
}

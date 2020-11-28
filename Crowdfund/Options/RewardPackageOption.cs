using Crowdfund.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Options
{
    public class RewardPackageOption
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Reward { get; set; }
        public int ProjectId { get; set; }
    }
}

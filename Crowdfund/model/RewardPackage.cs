using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.model
{
    public class RewardPackage
    {
        public int Id { get; set; }
        public decimal  Price { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public List<string> Reward{ get; set; }
    
    }
}


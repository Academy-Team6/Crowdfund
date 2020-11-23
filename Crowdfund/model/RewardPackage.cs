using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.model
{
    public class RewardPackage
    {
        public int Id { get; set; }
        public decimal  Price { get; set; }
        public Project Project { get; set; }
        public Reward? Reward{ get; set; }
    
    }

    public enum Reward
    {
        A, B, C, D
    }
}


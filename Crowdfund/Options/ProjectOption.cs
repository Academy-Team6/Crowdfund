using Crowdfund.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Options
{
    public class ProjectOption
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Photos { get; set; }
        public List<string> Videos { get; set; }
        public decimal TargetBudget { get; set; }
        public decimal CurrentBudget { get; set; }
        public decimal BudgetRatio { get; set; }
        public int ProjectCreatorId { get; set; }
        public List<int> RewardPackagesId { get; set; }
    }
}

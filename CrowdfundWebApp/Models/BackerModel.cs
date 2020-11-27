using Crowdfund.Options;
using System.Collections.Generic;

namespace CrowdfundWebApp.Models
{
    public class BackerModel
    {
        public List<BackerOption> Backers { get; set; }
    }
    public class BackerOptionModel
    {
        public BackerOption Backer { get; set; }
    }

}

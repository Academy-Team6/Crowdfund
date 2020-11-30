using Crowdfund.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundWebApp.Models
{
    public class StatusUpdateModel
    {
       public List<StatusUpdateOption> StatusUpdateOptions { get; set; }
    }
    public class StatusUpdateOptionModel
    {
        public StatusUpdateOption StatusUpdateOption { get; set; }
    }
}

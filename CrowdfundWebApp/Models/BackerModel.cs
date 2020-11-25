using Crowdfund.model;
using Crowdfund.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundWebApp.Models
{
    public class BackerModel
    {
        public List<BackerOption> Backers { get; set; }
        public class BackerOptionModel
        {
            public BackerOption Backer { get; set; }
        }

        public class BackerWithFileModel
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }
    }
}

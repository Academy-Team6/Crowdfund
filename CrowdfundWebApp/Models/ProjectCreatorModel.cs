using Crowdfund.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundWebApp.Models
{
    public class ProjectCreatorModel
    {
        public List<ProjectCreatorOption> ProjectCreators { get; set; }
    }
    public class ProjectCreatorOptionModel
    {
        public ProjectCreatorOption ProjectCreator { get; set; }
    }
}

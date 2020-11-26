using Crowdfund.Options;
using System.Collections.Generic;

namespace CrowdfundWebApp.Models
{
    public class ProjectModel
    {
        public List<ProjectOption> Projects { get; set; }
    }
    public class ProjectOptionModel
    {
        public ProjectOption Project { get; set; }
    }

}
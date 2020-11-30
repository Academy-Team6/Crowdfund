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
    public class ProjectViewModel
    {
        public ProjectOption Project { get; set; }
        public List<MediaOption> Media { get; set; }
        public List<StatusUpdateOption> StatusUpdateOptions { get; set; }

    }
}
public enum ProjectCategory
{
    Tech,
    Art,
    Sports,
    Health,
    Industry,
    Buisness,
    Gadget,
    Clothing
}
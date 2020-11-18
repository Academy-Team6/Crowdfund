using Crowdfund.model;
using Crowdfund.Options;
using System.Collections.Generic;

namespace Crowdfund.API
{
    public interface IProjectService
    {
        public ProjectOption CreateProject(ProjectOption projectOption);
        public ProjectOption FindProject(int id);
        public List<ProjectOption> FindAll();
        public List<ProjectOption> FindByCategory(ProjectCategory projectCategory);
        public List<ProjectOption> FindBySearch(string payload);
        public List<ProjectOption> FindByTrending();
        public ProjectOption UpdateProject(int id, ProjectOption projectOption);
        public bool DeleteProject(int id);
        public RewardPackageOption AddPackageToProject(int projectId, int rewardPackageId);
    }
}

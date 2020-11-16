using Crowdfund.model;
using Crowdfund.Options;
using System.Collections.Generic;

namespace Crowdfund.API
{
    public interface IProjectService
    {
        public ProjectOption CreateProject(ProjectOption projectOption);
        public ProjectOption FindProject(int id);
        public List<Project> FindAll();
        public List<Project> FindByCategory(ProjectCategory projectCategory);
        public List<Project> FindBySearch(string payload);
        public List<Project> FindByTrending();
        public ProjectOption UpdateProject(int id, ProjectOption projectOption);
        public bool DeleteProject(int id);
        public RewardPackageOption AddPackageToProject(int projectId, int rewardPackageId);
    }
}

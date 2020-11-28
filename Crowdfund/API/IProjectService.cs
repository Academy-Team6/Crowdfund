using Crowdfund.model;
using Crowdfund.Options;
using System.Collections.Generic;

namespace Crowdfund.API
{
    public interface IProjectService
    {
        ProjectOption CreateProject(ProjectOption projectOption);
        ProjectOption FindProject(int id);
        List<ProjectOption> FindAll();
        List<ProjectOption> FindByCategory(ProjectCategory projectCategory);
        List<ProjectOption> FindBySearch(string payload);
        List<ProjectOption> FindByTrending();
        List<ProjectOption> FindByProjectCreatorId(int projectCreatorId);
        ProjectOption UpdateProject(int id, ProjectOption projectOption);
        bool DeleteProject(int id);
        RewardPackageOption AddPackageToProject(int projectId, int rewardPackageId);
    }
}

using Crowdfund.Options;

namespace Crowdfund.API
{
    public interface IProjectService
    {
        public ProjectOption CreateProject(ProjectOption projectOption);
        public ProjectOption FindProject(int id);
        public ProjectOption UpdateProject(int id, ProjectOption projectOption);
        public bool DeleteProject(int id);
        public RewardPackageOption AddPackageToProject(int projectId, int rewardPackageId);
    }
}

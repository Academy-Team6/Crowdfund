using Crowdfund.Options;
using System.Collections.Generic;

namespace Crowdfund.API
{
    public interface IProjectCreatorService
    {
        ProjectCreatorOption CreateProjectCreator(ProjectCreatorOption projectCreatorOption);
        ProjectCreatorOption FindProjectCreator(int id);
        ProjectCreatorOption UpdateProjectCreator(int id, ProjectCreatorOption projectCreatorOption);
        bool DeleteProjectCreator(int id);
        List<ProjectCreatorOption> GetAllProjectCreators();
        List<ProjectCreatorOption> SearchProjectCreators(string searchCriteria);

    }
}

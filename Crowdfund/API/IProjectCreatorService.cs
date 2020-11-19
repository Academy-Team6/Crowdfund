using Crowdfund.Options;
using System.Collections.Generic;

namespace Crowdfund.API
{
    public interface IProjectCreatorService
    {
        public ProjectCreatorOption CreateProjectCreator(ProjectCreatorOption projectCreatorOption);
        public ProjectCreatorOption FindProjectCreator(int id);
        public ProjectCreatorOption UpdateProjectCreator(int id, ProjectCreatorOption projectCreatorOption);
        public bool DeleteProjectCreator(int id);
        public List<ProjectCreatorOption> GetAllProjectCreators();
        public List<ProjectCreatorOption> SearchProjectCreators(string searchCriteria);

    }
}

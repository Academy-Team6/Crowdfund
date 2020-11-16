using Crowdfund.Options;


namespace Crowdfund.API
{
    public interface IProjectCreatorService
    {
        public ProjectCreatorOption CreateProjectCreator(ProjectCreatorOption projectCreatorOption);
        public ProjectCreatorOption FindProjectCreator(int id);
        public ProjectCreatorOption UpdateProjectCreator(int id, ProjectCreatorOption projectCreatorOption);
        public bool DeleteProjectCreator(int id);
    }
}

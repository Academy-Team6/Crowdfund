using Crowdfund.API;
using Crowdfund.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Services
{
    public class ProjectServices : IProjectService
    {
        public RewardPackageOption AddPackageToProject(int projectId, int rewardPackageId)
        {
            throw new NotImplementedException();
        }

        public ProjectOption CreateProject(ProjectOption projectOption)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public ProjectOption FindProject(int id)
        {
            throw new NotImplementedException();
        }

        public ProjectOption UpdateProject(int id, ProjectOption projectOption)
        {
            throw new NotImplementedException();
        }
    }
}

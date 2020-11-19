using Crowdfund.API;
using Crowdfund.Data;
using Crowdfund.model;
using Crowdfund.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crowdfund.Services
{
    public class ProjectServices : IProjectService
    {
        private readonly CrowdfundDbContext dbContext;
        public ProjectServices(CrowdfundDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public RewardPackageOption AddPackageToProject(int projectId, int rewardPackageId)
        {
            var project = dbContext.Projects.Find(projectId);
            var rewardPackage = dbContext.RewardPackages.Find(rewardPackageId);
            dbContext.RewardPackages.Add(rewardPackage);
            dbContext.SaveChanges();
            return new RewardPackageOption()
            {
                Price = rewardPackage.Price,
                ProjectId = project.Id,
                Reward = rewardPackage.Reward
            };
        }

        public ProjectOption CreateProject(ProjectOption projectOption)
        {
            ProjectCreator projectCreator = dbContext.ProjectCreators.Find(projectOption.ProjectCreatorId);
            Project project = new Project()
            {
                CurrentBudget = projectOption.CurrentBudget,
                Description = projectOption.Description,
                Category = projectOption.Category,
                ProjectCreator = projectCreator,
                RewardPackages = new List<RewardPackage>(),
                TargetBudget = projectOption.TargetBudget,
                Title = projectOption.Title,
            };
            dbContext.Projects.Add(project);
            dbContext.SaveChanges();
            return projectOption;
        }

        public bool DeleteProject(int id)
        {
            Project project = dbContext.Projects.Find(id);
            if (project == null) return false;
            dbContext.Projects.Remove(project);
            dbContext.SaveChanges();
            return true;
        }
        private ProjectOption CreateProjectOption(Project project)
        {
            List<int> rewardPackagesId = new List<int>();
            foreach (RewardPackage rewardPackage in project.RewardPackages)
            {
                rewardPackagesId.Add(rewardPackage.Id);
            }
            return new ProjectOption()
            {
                BudgetRatio = project.BudgetRatio,
                Category = project.Category,
                CurrentBudget = project.CurrentBudget,
                Description = project.Description,
                Id = project.Id,
                ProjectCreatorId = project.ProjectCreator.Id,
                RewardPackagesId = rewardPackagesId,
                TargetBudget = project.TargetBudget,
                Title = project.Title
            };
        }
        public ProjectOption FindProject(int id)
        {
            Project project = dbContext.Projects.Find(id);
            List<int> rewardPackagesId = new List<int>();
            foreach (RewardPackage rewardPackage in project.RewardPackages)
            {
                rewardPackagesId.Add(rewardPackage.Id);
            }
            return CreateProjectOption(project);
        }

        public ProjectOption UpdateProject(int id, ProjectOption projectOption)
        {
            Project project = dbContext.Projects.Find(id);
            project.Category = projectOption.Category;
            project.Description = projectOption.Description;
            project.CurrentBudget = projectOption.CurrentBudget;
            project.TargetBudget = projectOption.TargetBudget;
            project.Title = projectOption.Title;
            dbContext.SaveChanges();
            return projectOption;
        }
        public List<ProjectOption> FindByTrending()
        {
            return lol;
        }
        public List<ProjectOption> FindBySearch(string payload)
        {
            

            return pOpt;
        }
    }
}

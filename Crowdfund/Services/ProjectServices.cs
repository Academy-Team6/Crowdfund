using Crowdfund.API;
using Crowdfund.Data;
using Crowdfund.model;
using Crowdfund.Options;
using System.Collections.Generic;
using System.Linq;

namespace Crowdfund.Services
{
    public class ProjectServices : IProjectService
    {
        private CrowdfundDbContext db = new CrowdfundDbContext();
        public RewardPackageOption AddPackageToProject(int projectId, int rewardPackageId)
        {
            var project = db.Set<Project>().Find(projectId);
            var rewardPackage = db.Set<RewardPackage>().Find(rewardPackageId);
            project.RewardPackages.Add(rewardPackage);
            db.SaveChanges();
            return new RewardPackageOption()
            {
                Price = rewardPackage.Price,
                ProjectId = project.Id,
                Reward = rewardPackage.Reward
            };
        }
        public ProjectOption CreateProject(ProjectOption projectOption)
        {
            ProjectCreator projectCreator = db.Set<ProjectCreator>().Find(projectOption.ProjectCreatorId);
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
            db.Set<Project>().Add(project);
            db.SaveChanges();
            return projectOption;
        }
        public bool DeleteProject(int id)
        {
            Project project = db.Set<Project>().Find(id);
            if (project == null) return false;
            db.Set<Project>().Remove(project);
            db.SaveChanges();
            return true;
        }
        public List<ProjectOption> FindAll()
        {
            List<Project> projectList = db.Set<Project>().ToList();
            List<ProjectOption> projectOptionList = new List<ProjectOption>();
           foreach(Project p in projectList)
            {
                projectOptionList.Add(CreateProjectOption(p));
            }
            return projectOptionList;
        }
        public List<ProjectOption> FindByCategory(ProjectCategory projectCategory)
        {
            List<Project>projectList=db.Set<Project>().Where(p => p.Category == projectCategory.ToString()).ToList();
            List<ProjectOption> projectOptionList = new List<ProjectOption>();
            foreach (Project p in projectList)
            {
                projectOptionList.Add(CreateProjectOption(p));
            }
            return projectOptionList;
        }
        public List<ProjectOption> FindBySearch(string payload)
        {
            List<Project> projectList = db.Set<Project>().Where(p => p.Description.Contains(payload)).ToList();
            List<ProjectOption> projectOptionList = new List<ProjectOption>();
            foreach (Project p in projectList)
            {
                projectOptionList.Add(CreateProjectOption(p));
            }
            return projectOptionList;
        }
        public List<ProjectOption> FindByTrending()
        {
            return db.Set<ProjectOption>().OrderBy(p => p.CurrentBudget).ThenBy(p=>p.BudgetRatio).ToList();
        }
        public ProjectOption FindProject(int id)
        {
            Project project = db.Set<Project>().Find(id);
            List<int> rewardPackagesId = new List<int>();
            foreach(RewardPackage rewardPackage in project.RewardPackages)
            {
                rewardPackagesId.Add(rewardPackage.Id);
            }
            return CreateProjectOption(project);
        }
        public ProjectOption UpdateProject(int id, ProjectOption projectOption)
        {
            Project project = db.Set<Project>().Find(id);
            project.Category = projectOption.Category;
            project.Description = projectOption.Description;
            project.CurrentBudget = projectOption.CurrentBudget;
            project.TargetBudget = projectOption.TargetBudget;
            project.Title = projectOption.Title;
            db.SaveChanges();
            return projectOption;
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
    }
}
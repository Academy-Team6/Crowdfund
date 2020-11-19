using Crowdfund.API;
using Crowdfund.Data;
using Crowdfund.model;
using Crowdfund.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crowdfund.Services
{
    
    public class ProjectCreatorServices : IProjectCreatorService
    {
        private readonly CrowdfundDbContext dbContext;
        public ProjectCreatorServices(CrowdfundDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ProjectCreatorOption CreateProjectCreator(ProjectCreatorOption pcOption)
        {
            ProjectCreator pc = new ProjectCreator
            {
                FirstName = pcOption.FirstName,
                LastName = pcOption.LastName,
                Description = pcOption.Description,
                Email = pcOption.Email
            };

            dbContext.ProjectCreators.Add(pc);
            dbContext.SaveChanges();
            return new ProjectCreatorOption
            {
                FirstName = pc.FirstName,
                LastName = pc.LastName,
                Description = pc.Description,
                Email = pc.Email
            };
        }

        public bool DeleteProjectCreator(int id)
        {
            ProjectCreator pc = dbContext.ProjectCreators.Find(id);
            if (pc == null) return false;
            dbContext.ProjectCreators.Remove(pc);
            dbContext.SaveChanges();
            return true;

        }

        public ProjectCreatorOption FindProjectCreator(int id)
        {
            ProjectCreator pc = dbContext.ProjectCreators.Find(id);
            return new ProjectCreatorOption
            {
                FirstName = pc.FirstName,
                LastName = pc.LastName,
                Description = pc.Description,
                Email = pc.Email,
                Id = pc.Id // might need fixing
            };
        }
        private static void ProjectCreatorOptToProjectCreator(ProjectCreatorOption pcOpt, ProjectCreator pc)
        {
            pc.FirstName = pcOpt.FirstName;
            pc.LastName = pcOpt.LastName;
            pc.Description = pcOpt.Description;
            pc.Email = pcOpt.Email;
        }
        public ProjectCreatorOption UpdateProjectCreator(int id, ProjectCreatorOption pcOption)
        {
            ProjectCreator pc = dbContext.ProjectCreators.Find(id);
            ProjectCreatorOptToProjectCreator(pcOption, pc);
            dbContext.SaveChanges();

            return new ProjectCreatorOption
            {
                FirstName = pc.FirstName,
                LastName =pc.LastName,
                Description = pc.Description,
                Email = pc.Email
            };
        }

        public List<ProjectCreatorOption> SearchProjectCreators(string searchCriteria)
        {
            // no need dependency injection using CrowdfundDbContext dbContext = new CrowdfundDbContext();
            List<ProjectCreator> pcs = dbContext.ProjectCreators
                .Where(pc => pc.FirstName.Contains(searchCriteria)
               || pc.LastName.Contains(searchCriteria)
                )
                .ToList();

            List<ProjectCreatorOption> pcOpt = new List<ProjectCreatorOption>();
            pcs.ForEach(pc => pcOpt.Add(new ProjectCreatorOption
            {
                FirstName = pc.FirstName,
                LastName = pc.LastName,
                Description = pc.Description,
                Email = pc.Email,
                Id = pc.Id //something is wrong ?
            }));

            return pcOpt;
        }
        public List<ProjectCreatorOption> GetAllProjectCreators()
        {
            List<ProjectCreator> pcs = dbContext.ProjectCreators.ToList(); 
            List<ProjectCreatorOption> pcOpt = new List<ProjectCreatorOption>();
            pcs.ForEach(pc => pcOpt.Add(new ProjectCreatorOption
            {
                FirstName = pc.FirstName,
                LastName = pc.LastName,
                Description = pc.Description,
                Email = pc.Email,
                Id = pc.Id //something is wrong ?
            }));

            return pcOpt;
        }
    }
}

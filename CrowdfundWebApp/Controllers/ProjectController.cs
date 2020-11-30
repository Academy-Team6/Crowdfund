using Crowdfund.API;
using Crowdfund.model;
using Crowdfund.Options;
using Crowdfund.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService projectService;
        public ProjectController(ILogger<ProjectController> logger, IProjectService _projectService)
        {
            _logger = logger;
            projectService = _projectService;
        }

        [HttpGet]
        public List<ProjectOption> GetAllProjects()
        {
            return projectService.FindAll();
        }
        [HttpGet("{id}")]
        public ProjectOption GetProjectById(int id)
        {
            return projectService.FindProject(id);
        }
        [HttpGet("search/trending")]
        public List<ProjectOption> GetTrendingProjects()
        {
            return projectService.FindByTrending();
        }
        [HttpGet("search/{category}")]
        public List<ProjectOption> GetProjectsByCategory(string category)
        {
            Crowdfund.model.ProjectCategory projectCategory = (Crowdfund.model.ProjectCategory)Enum.Parse(typeof(Crowdfund.model.ProjectCategory), category);
            return projectService.FindByCategory(projectCategory);
        }
        [HttpGet("search/{payload}")]
        public List<ProjectOption> GetProjectsBySearch(string payload)
        {
            return projectService.FindBySearch(payload); 
        }
        [HttpPost]
        public ProjectOption CreateProject([FromForm] ProjectOption projectOption)
        {
            return projectService.CreateProject(projectOption);
        }
        [HttpPost("{projectId}/{rewardPackageId}")]
        public RewardPackageOption AddRewardPackageToProject(int projectId, int rewardPackageId)
        {
            return projectService.AddPackageToProject(projectId, rewardPackageId);
        }
        [HttpDelete("{id}")]
        public bool DeleteProject(int id)
        {
            return projectService.DeleteProject(id);
        }
        [HttpPut("{id}")]
        public ProjectOption UpdateProject(int id,[FromForm] ProjectOption projectOption)
        {
            return projectService.UpdateProject(id, projectOption);
        }
    }
}

using Crowdfund.model;
using Crowdfund.Options;
using Crowdfund.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3rdPartyRESTAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private ProjectServices projectService = new ProjectServices();
        public ProjectController(ILogger<ProjectController> logger)
        {
            _logger = logger;
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
        [HttpGet("search/category")]
        public List<ProjectOption> GetProjectsByCategory(ProjectCategory category)
        {
            return projectService.FindByCategory(category);
        }
        [HttpGet("search/{payload}")]
        public List<ProjectOption> GetProjectsBySearch(string payload)
        {
            return projectService.FindBySearch(payload);
        }
        [HttpPost]
        public ProjectOption CreateProject(ProjectOption projectOption)
        {
            return projectService.CreateProject(projectOption);
        }
        [HttpPost("{projectId}/{rewardPackageId}")]
        public RewardPackageOption AddRewardPackageToProject(int projectId, int rewardPackageId)
        {
            return projectService.AddPackageToProject(projectId, rewardPackageId);
        }
        [HttpDelete]
        public bool DeleteProject(int id)
        {
            return projectService.DeleteProject(id);
        }
        [HttpPut("{id}")]
        public ProjectOption UpdateProject(int id, ProjectOption projectOption)
        {
            return projectService.UpdateProject(id, projectOption);
        }
    }
}

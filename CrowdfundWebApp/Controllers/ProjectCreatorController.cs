using Crowdfund.API;
using Crowdfund.Options;
using Crowdfund.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCreatorController : ControllerBase
    {
        private readonly ILogger<ProjectCreatorController> _logger;
        private readonly IProjectCreatorService _projectCreatorService;
        public ProjectCreatorController(ILogger<ProjectCreatorController> logger, IProjectCreatorService projectCreatorServices)
        {
            _logger = logger;
            _projectCreatorService = projectCreatorServices;
        }
        [HttpGet]
        public List<ProjectCreatorOption> GetAllProjectCreators()
        {
            return _projectCreatorService.GetAllProjectCreators();
        } 
        [HttpGet("{id}")]
        public ProjectCreatorOption FindProjectCreator(int id)
        {
            return _projectCreatorService.FindProjectCreator(id);
        }
        [HttpPost]
        public ProjectCreatorOption CreateProjectCreator(ProjectCreatorOption projectCreatorOption)
        {
            return _projectCreatorService.CreateProjectCreator(projectCreatorOption);
        }
        [HttpPut("{id}")]
        public ProjectCreatorOption UpdateProjectCreator(int id, ProjectCreatorOption projectCreatorOption)
        {
            return _projectCreatorService.UpdateProjectCreator(id, projectCreatorOption);
        }
        [HttpDelete("{id}")]
        public bool DeleteProjectCreator(int id)
        {
            return _projectCreatorService.DeleteProjectCreator(id);
        }
    }
}

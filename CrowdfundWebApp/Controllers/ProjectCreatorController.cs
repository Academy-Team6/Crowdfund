using Crowdfund.Options;
using Crowdfund.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3rdPartyRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCreatorController : ControllerBase
    {
        private readonly ILogger<ProjectCreatorController> _logger;
        private ProjectCreatorServices projectCreatorService = new ProjectCreatorServices();
        public ProjectCreatorController(ILogger<ProjectCreatorController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public List<ProjectCreatorOption> GetAllProjectCreators()
        {
            return projectCreatorService.GetAllProjectCreators();
        } 
        [HttpGet("{id}")]
        public ProjectCreatorOption FindProjectCreator(int id)
        {
            return projectCreatorService.FindProjectCreator(id);
        }
        [HttpPost]
        public ProjectCreatorOption CreateProjectCreator(ProjectCreatorOption projectCreatorOption)
        {
            return projectCreatorService.CreateProjectCreator(projectCreatorOption);
        }
        [HttpPut("{id}")]
        public ProjectCreatorOption UpdateProjectCreator(int id, ProjectCreatorOption projectCreatorOption)
        {
            return projectCreatorService.UpdateProjectCreator(id, projectCreatorOption);
        }
        [HttpDelete]
        public bool DeleteProjectCreator(int id)
        {
            return projectCreatorService.DeleteProjectCreator(id);
        }
    }
}

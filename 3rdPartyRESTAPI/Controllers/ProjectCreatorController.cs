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

    }
}

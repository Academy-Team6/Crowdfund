using Crowdfund.API;
using Crowdfund.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusUpdateController : ControllerBase
    {
        private readonly IStatusUpdateService statusUpdateService;
        public StatusUpdateController(IStatusUpdateService statusUpdateService)
        {
            this.statusUpdateService = statusUpdateService;
        }
        [HttpGet]
        public List<StatusUpdateOption> GetStatusUpdatesOfProject(int id)
        {
            return statusUpdateService.GetStatusUpdates(id);
        }
        [HttpPost]
        public StatusUpdateOption AddStatusUpdate([FromForm]StatusUpdateOption statusUpdateOption)
        {
            return statusUpdateService.AddStatusUpdate(statusUpdateOption);
        }
        [HttpDelete("{id}")]
        public bool DeleteStatusUpdate(int id)
        {
            return statusUpdateService.DeleteStatusUpdate(id);
        }
    }
}

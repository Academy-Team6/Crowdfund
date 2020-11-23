using Crowdfund.model;
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
    public class MediaController : ControllerBase
    {

        private readonly ILogger<MediaController> _logger;
        private MediaServices mediaService;
        public MediaController(ILogger<MediaController> logger, MediaServices _mediaService)
        {
            _logger = logger;
            mediaService = _mediaService;
        }
        [HttpGet("{projectId}")]
        public List<MediaOption> GetMediaForProject(int projectId)
        {
            return mediaService.FindAllMediaofProject(projectId);
        }
        [HttpPost("addMedia")]
        public MediaOption CreateMediaAndAddItToProject(MediaOption mediaOption)
        {
            return mediaService.CreateMedia(mediaOption);
        }
        [HttpDelete("{mediaId}")]
        public bool DeleteMedia(int mediaId)
        {
            return mediaService.DeleteMedia(mediaId);
        }
        [HttpGet("{mediaId}")]
        public MediaOption FindMedia(int mediaId)
        {
            return mediaService.FindMedia(mediaId);
        }
        [HttpPut("{mediaId}")]
        public MediaOption UpdateMedia(int mediaId, MediaOption mediaOption)
        {
            return mediaService.UpdateMedia(mediaId, mediaOption);
        }
    }
}

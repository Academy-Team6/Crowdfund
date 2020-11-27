
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Crowdfund.API;
using Crowdfund.Options;


namespace CrowdfundWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardPackageController : ControllerBase
    {

        private readonly IRewardPackageService rewardPackageService;
        private readonly IProjectService projectService;
        public RewardPackageController(IRewardPackageService rewardPackageService, IProjectService projectService)
        {
            this.rewardPackageService = rewardPackageService;
            this.projectService = projectService;
        }

        [HttpGet("{id}")]
        public RewardPackageOption GetRewardPackage(int id)
        {
            return rewardPackageService.GetRewardPackage(id);
        }

        [HttpGet]
        public List<RewardPackageOption> GetAllRewardPackages()
        {
            return rewardPackageService.GetAllRewardPackages();
        }

        [HttpPost]
        public RewardPackageOption CreateRewardPackage([FromForm] RewardPackageOption rewardPackageOption)
        {
            RewardPackageOption rewardPackage = rewardPackageService.CreateRewardPackage(rewardPackageOption);
            RewardPackageOption reward=projectService.AddPackageToProject(rewardPackage.ProjectId,rewardPackage.Id);

            return reward ;
        }

        [HttpPut("{id}")]
        public RewardPackageOption UpdateRewardPackage(int id,[FromForm]RewardPackageOption rewardPackageOption)
        {
            return rewardPackageService.UpdateRewardPackage(id, rewardPackageOption);
        }

        [HttpGet("{id}")]
        public RewardPackageOption FindRewardPackage(int id)
        {
            return rewardPackageService.FindRewardPackageById(id);
        }
        [HttpDelete("{id}")]
        public bool DeleteRewardPackage(int id)
        {
            return rewardPackageService.DeleteRewardPackage(id);
        }
    }
}

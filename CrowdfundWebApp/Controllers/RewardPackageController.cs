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
        public IRewardPackageService rewardPackageService;
        public RewardPackageController(IRewardPackageService rewardPackageService)
        {
            this.rewardPackageService = rewardPackageService;
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
        public RewardPackageOption CreateRewardPackage(RewardPackageOption rewardPackageOption)
        {
            return rewardPackageService.CreateRewardPackage(rewardPackageOption);
        }

        [HttpPut("{id}")]
        public RewardPackageOption UpdateRewardPackage(int id, RewardPackageOption rewardPackageOption)
        {
            return rewardPackageService.UpdateRewardPackage(id, rewardPackageOption);
        }

        [HttpGet("{id}")]
        public RewardPackageOption FindRewardPackage(int id)
        {
            return rewardPackageService.FindRewardPackageById(id);
        }


    }
}

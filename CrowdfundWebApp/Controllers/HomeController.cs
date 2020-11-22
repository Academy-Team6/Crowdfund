using Crowdfund.API;
using Crowdfund.Options;
using CrowdfundWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static CrowdfundWebApp.Models.BackerModel;

namespace CrowdfundWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBackerService backerService;
        private readonly IRewardPackageService rewardPackageService;
        private readonly IMediaService mediaService;
        private readonly IProjectService projectService;
        private readonly IProjectCreatorService projectCreatorService;
        private readonly ITransactionService transactionService;

        public HomeController(ILogger<HomeController> logger, IBackerService _backerService, IRewardPackageService _rewardPackageService, IMediaService _mediaService , IProjectService _projectService , IProjectCreatorService _projectCreatorService, ITransactionService _transactionService)
        {
            _logger = logger;
            backerService = _backerService;
            rewardPackageService = _rewardPackageService;
            mediaService = _mediaService;
            projectService = _projectService;
            projectCreatorService = _projectCreatorService;
            transactionService = _transactionService;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Hello World!");
            return View();
        }
        public IActionResult Backer()
        {
            List<BackerOption> backer = backerService.GetAllBackers();
            BackerModel backerModel = new BackerModel
            {
                Backers = backer
            };
            return View(backerModel);
        }
        public IActionResult AddBacker()
        {
            return View();
        }
        public IActionResult DeleteBacker()
        {
            return View();
        }
        public IActionResult UpdateBacker()
        {
            return View();
        }
        public IActionResult DeleteBackerFromView([FromRoute] int id)
        {
            backerService.DeleteBacker(id);

            return Redirect("/Home/Backer");
        }
        public IActionResult FindBacker()
        {
            return View();
        }
        public IActionResult UpdateBackerWithDetails([FromRoute] int id)
        {
            BackerOption backerOptions = backerService.FindBacker(id);
            BackerOptionModel model = new BackerOptionModel {Backer = backerOptions };

            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

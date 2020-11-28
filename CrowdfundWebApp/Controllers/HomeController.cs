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
        private readonly ILoginService loginService;

        public HomeController(ILogger<HomeController> logger, ILoginService _loginService, IBackerService _backerService, IRewardPackageService _rewardPackageService, IMediaService _mediaService , IProjectService _projectService , IProjectCreatorService _projectCreatorService, ITransactionService _transactionService)
        {
            _logger = logger;
            backerService = _backerService;
            rewardPackageService = _rewardPackageService;
            mediaService = _mediaService;
            projectService = _projectService;
            projectCreatorService = _projectCreatorService;
            transactionService = _transactionService;
            loginService = _loginService;
        }

        //login
        public IActionResult Login()
        {
                return View();
        }

        //ProjectCreator Views
        public IActionResult ProjectCreator()
        {
            List<ProjectCreatorOption> projectCreators = projectCreatorService.GetAllProjectCreators();
            ProjectCreatorModel projectCreatorModel = new ProjectCreatorModel()
            {
                ProjectCreators = projectCreators
            };
            return View(projectCreatorModel);
        }

        public IActionResult AddProjectCreator()
        {
            return View();
        }
        public IActionResult UpdateProjectCreator([FromRoute] int id)
        {
            ProjectCreatorOption projectCreatorOption = projectCreatorService.FindProjectCreator(id);
            ProjectCreatorOptionModel projectCreatorOptionModel = new ProjectCreatorOptionModel() { ProjectCreator = projectCreatorOption };
            return View(projectCreatorOptionModel);
        }
        public IActionResult DeleteProjectCreator([FromRoute] int id)
        {
             ProjectCreatorOption projectCreatorOption = projectCreatorService.FindProjectCreator(id);
            ProjectCreatorOptionModel projectCreatorOptionModel = new ProjectCreatorOptionModel() { ProjectCreator = projectCreatorOption };
            return View(projectCreatorOptionModel);
        }
        //Project Views

        public IActionResult Project()
        {
            List<ProjectOption> projects = projectService.FindAll();
            ProjectModel projectModel = new ProjectModel()
            {
                Projects = projects
            };
            return View(projectModel);
        }
        public IActionResult BackerProject()
        {
            List<ProjectOption> projects = projectService.FindAll();
            ProjectModel projectModel = new ProjectModel()
            {
                Projects = projects
            };
            return View(projectModel);
        }
        public IActionResult ViewProject([FromRoute] int id)
        {
            ProjectOption projectOption = projectService.FindProject(id);
            ProjectOptionModel projectOptionModel = new ProjectOptionModel() { Project = projectOption };
            return View(projectOptionModel);
        }
        public IActionResult AddProject()
        {
            return View();
        }
        public IActionResult UpdateProject([FromRoute] int id)
        {
            ProjectOption projectOption = projectService.FindProject(id);
            ProjectOptionModel projectOptionModel = new ProjectOptionModel() { Project = projectOption };
            return View(projectOptionModel);
        }
        public IActionResult DeleteProject([FromRoute] int id)
        {
            ProjectOption projectOption = projectService.FindProject(id);
            ProjectOptionModel projectOptionModel = new ProjectOptionModel() { Project = projectOption };
            return View(projectOptionModel);
        }

     
        //Backer Views

        public IActionResult Backer()
        {
            List<BackerOption> backer = backerService.GetAllBackers();
            BackerModel backerModel = new BackerModel
            {
                Backers = backer
            };
            return View(backerModel);
        }
        public IActionResult MBacker()
        {
            return View();
        }
        public IActionResult FindBackerDisplay([FromQuery] string text)
        {
            List<BackerOption> backers = backerService.SearchBackers(text);
            BackerModel backerModel = new BackerModel
            {
                Backers = backers
            };

            return View("Backer", backerModel);

        }
        public IActionResult UpdateBacker([FromRoute] int id)
        {
            BackerOption backerOption = backerService.FindBacker(id);
            BackerOptionModel backerOptionModel = new BackerOptionModel() { Backer = backerOption };
            return View(backerOptionModel);
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

        //RewardPackage Views
        public IActionResult RewardPackage()
        {
            List<RewardPackageOption> rewardPackages = rewardPackageService.GetAllRewardPackages();
            RewardPackageModel rewardPackagesModel = new RewardPackageModel()
            {
                RewardPackages = rewardPackages
            };
            return View(rewardPackagesModel);
        }
        public IActionResult AddRewardPackage()
        {
            return View();
        }
        public IActionResult UpdateRewardPackage([FromRoute] int id)
        {
            RewardPackageOption rewardPackageOption = rewardPackageService.FindRewardPackageById(id);
            RewardPackageOptionModel rewardPackageOptionModel = new RewardPackageOptionModel() { RewardPackage = rewardPackageOption };
            return View(rewardPackageOptionModel);
        }
        public IActionResult DeleteRewardPackage([FromRoute] int id)
        {
            RewardPackageOption rewardPackageOption = rewardPackageService.FindRewardPackageById(id);
            RewardPackageOptionModel rewardPackageOptionModel = new RewardPackageOptionModel() { RewardPackage = rewardPackageOption };
            return View(rewardPackageOptionModel);
        }
        // Transaction Views
        public IActionResult Transaction()
        {
            List<TransactionOption> transactions = transactionService.GetAllTransactions();
            TransactionModel transactionModel = new TransactionModel()
            {
                Transactions = transactions
            };
            return View(transactionModel);
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

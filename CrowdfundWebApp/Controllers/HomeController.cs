using Crowdfund.API;
using Crowdfund.model;
using Crowdfund.Options;
using CrowdfundWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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

        public HomeController(ILogger<HomeController> logger, ILoginService _loginService, IBackerService _backerService, IRewardPackageService _rewardPackageService, IMediaService _mediaService, IProjectService _projectService, IProjectCreatorService _projectCreatorService, ITransactionService _transactionService)
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

        //ProjectCreator Profile
        public IActionResult ProjectCreatorProfile([FromQuery] int projectCreatorId)
        {
            ProjectCreatorOption projectCreatorOption = projectCreatorService.FindProjectCreator(projectCreatorId);
            ProjectCreatorOptionModel projectCreatorOptionModel = new ProjectCreatorOptionModel()
            {
                ProjectCreator = projectCreatorOption
            };
            return View(projectCreatorOptionModel);
        }
        //ProjectCreator Dashboard
        public IActionResult Dashboard([FromQuery] int projectCreatorId)
        {
            List<ProjectOption> projectOptions = projectService.FindByProjectCreatorId(projectCreatorId);

            ProjectModel projectModel = new ProjectModel()
            {
                Projects = projectOptions
            };
            return View(projectModel);
        }
        //Add media View
        public IActionResult AddMedia()
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
        public IActionResult ViewProject([FromQuery] int projectId)
        {
            ProjectOption projectOption = projectService.FindProject(projectId);
            List<MediaOption> mediaOption = mediaService.FindAllMediaofProject(projectId);
            ProjectViewModel projectViewModel = new ProjectViewModel()
            {
                Project = projectOption,
                Media = mediaOption
            };
            return View(projectViewModel);
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
        public IActionResult TrendingProjects()
        {
            List<ProjectOption> projectOptions = projectService.FindByTrending();
            ProjectModel projectModel = new ProjectModel()
            {
                Projects = projectOptions
            };
            return View(projectModel);
        }
        public IActionResult BrowseByCategory()
        {
            return View();
        }
        public IActionResult Browse([FromQuery] string category )
        {
            Enum.TryParse(category, out Crowdfund.model.ProjectCategory projectCategory);
            List<ProjectOption> projectOptions = projectService.FindByCategory(projectCategory);
            ProjectModel projectModel = new ProjectModel()
            {
                Projects = projectOptions
            };
        return View(projectModel);
        }
        //Backer Views

        //Backer Profile
        public IActionResult BackerProfile([FromQuery] int backerId)
        {
            BackerOption backerOption = backerService.FindBacker(backerId);
            BackerOptionModel backerOptionModel = new BackerOptionModel()
            {
                Backer = backerOption
            };
            return View(backerOptionModel);
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
        public IActionResult MBacker()
        {
            return View();
        }
        public IActionResult AddBacker()
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
        public IActionResult BackedProjects([FromQuery] int backerId)
        {
            List<TransactionOption> transactionOptions = transactionService.BackedProjects(backerId);

            TransactionModel transactionModel = new TransactionModel()
            {
                Transactions = transactionOptions
            };
            return View(transactionModel);
        }
        public IActionResult GetMyTransactions([FromQuery] int backerId)
        {
            List<TransactionOption> transactionOptions = transactionService.GetMyTransactions(backerId);

            TransactionModel transactionModel = new TransactionModel()
            {
                Transactions = transactionOptions
            };
            return View(transactionModel);
        }
        public IActionResult ProjectRewardPackage()
        {
            List<RewardPackageOption> rewardPackages = rewardPackageService.GetAllRewardPackages();
            RewardPackageModel rewardpackageModel = new RewardPackageModel()
            {
                RewardPackages = rewardPackages
            };
            return View(rewardpackageModel);
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

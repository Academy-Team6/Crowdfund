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
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService _loginService)
        {
            loginService = _loginService;
        }

        [HttpPost]
        public LoginAnswerOption Login([FromBody] LoginOption loginOption)
        {
            LoginAnswerOption loginAnswerOption = loginService.TryLogin(loginOption);
            if (loginAnswerOption.TypeOfUser != null) return loginAnswerOption;
            //ViewBag.CustomerType = loginAnswerOption.TypeOfUser;
            return null;
        }
    }
}

using Crowdfund.API;
using Crowdfund.Data;
using Crowdfund.model;
using Crowdfund.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crowdfund.Services
{
    public class LoginServices : ILoginService
    {
        private readonly CrowdfundDbContext dbContext;
        public LoginServices(CrowdfundDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public LoginAnswerOption TryLogin(LoginOption loginOption)
        {
            Backer backer = dbContext
                .Set<Backer>()
                .Where(o => o.FirstName == loginOption.Username && o.LastName==loginOption.Password)
                .SingleOrDefault();
            if (backer != null) return new LoginAnswerOption()
            {
                Id = backer.Id,
                TypeOfUser = "Backer"
            };
            ProjectCreator projectCreator = dbContext
                .Set<ProjectCreator>()
                .Where(o => o.FirstName == loginOption.Username && o.LastName == loginOption.Password)
                .SingleOrDefault();
            if (projectCreator.FirstName == "admin") return new LoginAnswerOption()
            {
                Id = projectCreator.Id,
                TypeOfUser = "admin"
            };
            if (projectCreator != null) return new LoginAnswerOption()
            {
                Id = projectCreator.Id,
                TypeOfUser = "ProjectCreator"
            };

            return new LoginAnswerOption()
            {
                Id = 0,
                TypeOfUser = null
            };
        }
    }
}

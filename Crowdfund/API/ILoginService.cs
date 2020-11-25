using Crowdfund.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.API
{
    public interface ILoginService
    {
        LoginAnswerOption TryLogin(LoginOption loginOption);
    }
}

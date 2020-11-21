using Crowdfund.Options;
using System.Collections.Generic;

namespace Crowdfund.API
{
    public interface IBackerService
    {
        BackerOption CreateBacker(BackerOption backerOption);
        BackerOption FindBacker(int id);
        BackerOption UpdateBacker(int id, BackerOption backerOption);
        bool DeleteBacker(int id);
        List<BackerOption> GetAllBackers();
        List<BackerOption> SearchBackers(string searchCriteria);

    }
}
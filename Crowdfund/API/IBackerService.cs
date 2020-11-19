using Crowdfund.Options;
using System.Collections.Generic;

namespace Crowdfund.API
{
    public interface IBackerService
    {
        public BackerOption CreateBacker(BackerOption backerOption);
        public BackerOption FindBacker(int id);
        public BackerOption UpdateBacker(int id, BackerOption backerOption);
        public bool DeleteBacker(int id);
        public List<BackerOption> GetAllBackers();
        public List<BackerOption> SearchBackers(string searchCriteria);

    }
}
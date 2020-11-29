using Crowdfund.Options;
using System.Collections.Generic;

namespace Crowdfund.API
{
    public interface IStatusUpdateService
    {
        StatusUpdateOption AddStatusUpdate(StatusUpdateOption statusUpdateOption);
        bool DeleteStatusUpdate(int id);
        List<StatusUpdateOption> GetStatusUpdates(int projectId);

    }
}

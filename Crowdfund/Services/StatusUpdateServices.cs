using Crowdfund.API;
using Crowdfund.Data;
using Crowdfund.model;
using Crowdfund.Options;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Crowdfund.Services
{
    public class StatusUpdateServices : IStatusUpdateService
    {
        private readonly CrowdfundDbContext db = new CrowdfundDbContext(); 
        public StatusUpdateOption AddStatusUpdate(StatusUpdateOption statusUpdateOption)
        {
            Project project = db.Set<Project>().Find(statusUpdateOption.ProjectId);
            StatusUpdate statusUpdate = new StatusUpdate() {
               Overload = statusUpdateOption.Payload,
                Timestamp = statusUpdateOption.Timestamp,
                Project = project
            };
            project.StatusUpdates.Add(statusUpdate);
            db.Set<StatusUpdate>().Add(statusUpdate);
            db.SaveChanges();
            return statusUpdateOption;
        }

        public bool DeleteStatusUpdate(int id)
        {
            StatusUpdate statusUpdate = db.Set<StatusUpdate>().Find(id);
            if (statusUpdate == null) return false;
            db.Set<StatusUpdate>().Remove(statusUpdate);
            return true;
        }

        public List<StatusUpdateOption> GetStatusUpdates(int projectId)
        {
            List<StatusUpdate> statusUpdates = db
                .Set<StatusUpdate>()
                .Include(o => o.Project)
                .Where(o => o.Project.Id == projectId)
                .ToList();
            List<StatusUpdateOption> statusUpdateOptions = new List<StatusUpdateOption>();
            foreach(var su in statusUpdates)
            {
                statusUpdateOptions.Add(GetOptionFromModel(su));
            }
            return statusUpdateOptions;
        }
        private StatusUpdateOption GetOptionFromModel(StatusUpdate statusUpdate )
        {
            return new StatusUpdateOption()
            {
                Id = statusUpdate.Id,
                Payload = statusUpdate.Overload,
                ProjectId = statusUpdate.Project.Id,
                Timestamp = statusUpdate.Timestamp
            };
        }
    }
}

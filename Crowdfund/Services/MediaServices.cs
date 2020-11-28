using Crowdfund.API;
using Crowdfund.Data;
using Crowdfund.model;
using Crowdfund.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crowdfund.Services
{
    public class MediaServices : IMediaService
    {
        private readonly CrowdfundDbContext db;
        public MediaServices(CrowdfundDbContext _db)
        {
            db = _db;
        }
       
        public MediaOption CreateMedia(MediaOption mediaOption)
        {
            Project project = db.Set<Project>().Where(o=>o.Id==mediaOption.ProjectId).Include(o=>o.Medias).SingleOrDefault();
            Media media = new Media()
            {
                Payload = mediaOption.Payload,
                Type = mediaOption.Type,
                Project = project
            };
            
                var newMedia = db.Set<Media>().Add(media);
                db.SaveChanges();
                project.Medias.Add(newMedia.Entity);
                db.SaveChanges();

            return new MediaOption()
            {
                Payload = media.Payload,
                Type = media.Type,
                ProjectId = mediaOption.ProjectId
            };
        }
        public bool DeleteMedia(int id)
        {
            Media media = db.Set<Media>().Find(id);
            if (media == null) return false;
            db.Set<Media>().Remove(media);
            return true;
        }
        public MediaOption FindMedia(int id)
        {
            Media media = db.Set<Media>().Find(id);
            return new MediaOption()
            {
                Id=media.Id,
                Payload = media.Payload,
                Type = media.Type,
                 ProjectId=media.Project.Id
            };
        }

        public List<MediaOption> FindAllMediaofProject(int projectId)
        {
            Project project = db.Set<Project>()
                .Where(o=>o.Id==projectId)
                .Include(o=>o.Medias)
                .SingleOrDefault();
            List<MediaOption> projectMedia = new List<MediaOption>();
            foreach(Media media in project.Medias)
            {
                MediaOption mediaOption = new MediaOption()
                {
                    Id = media.Id,
                    Payload = media.Payload,
                    ProjectId = media.Project.Id,
                    Type = media.Type
                };
                projectMedia.Add(mediaOption);
            }
            return projectMedia;
        }

        public MediaOption UpdateMedia(int id, MediaOption mediaOption)
        {
            Media media = db.Set<Media>().Find(id);
            media.Payload = mediaOption.Payload;
            media.Type = mediaOption.Type;
            db.SaveChanges();
            return mediaOption;
        }
    }
}

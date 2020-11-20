using Crowdfund.API;
using Crowdfund.Data;
using Crowdfund.model;
using Crowdfund.Options;
using System.Collections.Generic;

namespace Crowdfund.Services
{
    public class MediaServices : IMediaService
    {
        private CrowdfundDbContext db = new CrowdfundDbContext();
        public MediaOption CreateMedia(MediaOption mediaOption)
        {
            Media media = new Media()
            {
                Payload = mediaOption.Payload,
                Type = mediaOption.Type,
                ProjectId = mediaOption.ProjectId
            };
            db.Set<Media>().Add(media);
            Project project = db.Set<Project>().Find(mediaOption.ProjectId);
            if (media.Type == "Photo")
            {
                project.Photos.Add((Photo)media);
            }
            if (media.Type == "Video")
            {
                project.Videos.Add((Video)media);
            }
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
                Type = media.Type
            };
        }

        public List<MediaOption> FindAllMediaofProject(int projectId)
        {
            Project project = db.Set<Project>().Find(projectId);
            List<MediaOption> projectMedia = new List<MediaOption>();
            foreach(Photo photo in project.Photos)
            {
                MediaOption mediaOption = new MediaOption()
                {
                    Id = photo.Id,
                    Payload = photo.Payload,
                    ProjectId = photo.ProjectId,
                    Type = photo.Type
                };
                projectMedia.Add(mediaOption);
            }
            foreach (Video video in project.Videos)
            {
                MediaOption mediaOption = new MediaOption()
                {
                    Id = video.Id,
                    Payload = video.Payload,
                    ProjectId = video.ProjectId,
                    Type = video.Type
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

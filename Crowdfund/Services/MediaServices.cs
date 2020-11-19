using Crowdfund.API;
using Crowdfund.Data;
using Crowdfund.model;
using Crowdfund.Options;

namespace Crowdfund.Services
{
    public class MediaServices : IMediaService
    {
        private CrowdfundDbContext db = new CrowdfundDbContext();
        public MediaOption AddMediaToProject(int mediaId, int projectId)
        {
            Media media = db.Set<Media>().Find(mediaId);
            Project project = db.Set<Project>().Find(projectId);
            if (media.Type == "Photo"){
                project.Photos.Add((Photo)media);
                }
            if (media.Type == "Video")
            {
                project.Videos.Add((Video)media);
            }
            return new MediaOption()
            {
                Payload = media.Payload,
                Type = media.Type,
                Id = media.Id
            };
        }
        public MediaOption CreateMedia(string type,string payload)
        {
            Media media = new Media()
            {
                Payload = payload,
                Type = type
            };
            db.Set<Media>().Add(media);
            db.SaveChanges();
            return new MediaOption()
            {
                Payload = media.Payload,
                Type = media.Type
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

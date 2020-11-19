using Crowdfund.Options;

namespace Crowdfund.API
{
    public interface IMediaService
    {
        public MediaOption CreateMedia(string type,string payload);
        public bool DeleteMedia(int id);
        public MediaOption FindMedia(int id);
        public MediaOption UpdateMedia(int id, MediaOption mediaOption);
        public MediaOption AddMediaToProject(int mediaid, int projectid);
    }
}
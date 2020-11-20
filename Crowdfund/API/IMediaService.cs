using Crowdfund.Options;
using System.Collections.Generic;

namespace Crowdfund.API
{
    public interface IMediaService
    {
        public MediaOption CreateMedia(MediaOption mediaOption);
        public bool DeleteMedia(int id);
        public MediaOption FindMedia(int id);
        public MediaOption UpdateMedia(int id, MediaOption mediaOption);
        public List<MediaOption> FindAllMediaofProject(int projectId);
    }
}
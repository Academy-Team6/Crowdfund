using Crowdfund.Options;
using System.Collections.Generic;

namespace Crowdfund.API
{
    public interface IMediaService
    {
        MediaOption CreateMedia(MediaOption mediaOption);
        bool DeleteMedia(int id);
        MediaOption FindMedia(int id);
        MediaOption UpdateMedia(int id, MediaOption mediaOption);
        List<MediaOption> FindAllMediaofProject(int projectId);
    }
}
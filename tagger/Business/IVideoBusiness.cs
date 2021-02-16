using System.Collections.Generic;
using tagger.Models;

namespace tagger.Business
{
    public interface IVideoBusiness
    {
        List<Video> GetVideo();

        List<Video> GetVideoByTag(string tag);

        Video TagVideo(Video video);
    }
}
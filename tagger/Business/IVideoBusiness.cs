using System.Collections.Generic;
using tagger.Models;

namespace tagger.Business
{
    public interface IVideoBusiness
    {
        List<Video> GetVideo();

        Video TagVideo(Video video);
    }
}
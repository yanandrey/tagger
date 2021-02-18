using System.Collections.Generic;
using System.Threading.Tasks;
using tagger.Models;

namespace tagger.Business
{
    public interface IVideoBusiness
    {
        Task<List<Video>> GetVideoAsync();

        List<Video> GetVideoByTag(string tag);

        Task<Video> TagVideoAsync(Video video);

        Task<Video> UpdateVideoAsync(Video video);

        Task<Video> DeleteVideoAsync(Video video);
    }
}
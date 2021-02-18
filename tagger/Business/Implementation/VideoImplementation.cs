using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using tagger.Models;

namespace tagger.Business.Implementation
{
    public class VideoImplementation : IVideoBusiness
    {
        private readonly IMongoCollection<Video> _videos;
        
        public VideoImplementation()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("VideosDb");
            _videos = database.GetCollection<Video>("videos");
        }

        public async Task<List<Video>> GetVideoAsync()
        {
            return await _videos.Find(new BsonDocument()).ToListAsync();
        }

        public List<Video> GetVideoByTag(string tag)
        {
            if (!string.IsNullOrWhiteSpace(tag))
            {
                return _videos.FindSync(x => x.Tags.Contains(tag)).ToList();
            }

            return null;
        }

        public async Task<Video> TagVideoAsync(Video video)
        {
            await _videos.InsertOneAsync(video);
            return video;
        }

        public async Task<Video> UpdateVideoAsync(Video video)
        {
            var result = _videos.Find(x => x.Link == video.Link);
            if (result != null)
            {
                await _videos.ReplaceOneAsync(x => x.Link == video.Link, video);
                return video;
            }
            
            return null;
        }

        public async Task<Video> DeleteVideoAsync(Video video)
        {
            var result = _videos.Find(x => x.Link == video.Link);
            if (result != null)
            {
                await _videos.DeleteOneAsync(x => x.Link == video.Link);
                return video;
            }
            
            return null;
        }
    }
}
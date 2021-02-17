using System.Collections.Generic;
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

        public List<Video> GetVideo()
        {
            return _videos.Find(new BsonDocument()).ToList();
        }
        
        public List<Video> GetVideoByTag(string tag)
        {
            if (!string.IsNullOrWhiteSpace(tag))
            {
                return _videos.FindSync(x => x.Tags.Contains(tag)).ToList();
            }

            return null;
        }

        public Video TagVideo(Video video)
        {
            _videos.InsertOne(video);
            return video;
        }

        public Video UpdateVideo(Video video)
        {
            var result = _videos.Find(x => x.Link == video.Link);
            if (result != null)
            {
                _videos.ReplaceOne(x => x.Link == video.Link, video);
                return video;
            }
            
            return null;
        }
    }
}
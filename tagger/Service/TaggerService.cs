using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using tagger.Models;

namespace tagger.Service
{
    public class TaggerService
    {
        private readonly IMongoCollection<Video> _videos;
        
        public TaggerService(IDatabaseServices settings)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("VideosDb");
            _videos = database.GetCollection<Video>("videos");
        }

        public List<Video> Get()
        {
            return _videos.Find(new BsonDocument()).ToList();
        }

        public Video Create(Video video)
        {
            _videos.InsertOne(video);
            return video;
        }
    }
}
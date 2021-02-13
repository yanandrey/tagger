using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace tagger.Models
{
    [BsonIgnoreExtraElements] 
    public class Video
    {
        public string Title { get; set; }
        
        public string Link { get; set; }
        
        public List<string> Tags { get; set; }
    }
}
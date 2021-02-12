using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace tagger.Models
{
    public class Video
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        
        public string Link { get; set; }
    }
}
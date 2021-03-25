using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace dimaticaAPI.Models
{
    public class Duty
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

    }
}

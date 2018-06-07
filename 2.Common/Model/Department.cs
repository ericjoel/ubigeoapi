using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Common.Model
{
    public class Department
    {
        [BsonElement("_id")]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("created_at")]
        public string CreatedAt { get; set; }
        [BsonElement("updated_at")]
        public string UpdatedAt { get; set; }
    }
}

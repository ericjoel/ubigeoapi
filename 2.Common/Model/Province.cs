using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Common.Model
{
    public class Province
    {
        [BsonElement("_id")]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("department_id")]
        public string IdDepartment { get; set; }
        [BsonElement("created_at")]
        public string CreatedAt { get; set; }
        [BsonElement("updated_at")]
        public string UpdatedAt { get; set; }
    }
}

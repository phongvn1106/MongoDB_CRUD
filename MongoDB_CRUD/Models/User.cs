using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDB_CRUD.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("userName")]
        public string FirstName { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }
    }
}

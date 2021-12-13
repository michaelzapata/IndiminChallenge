using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Indimin.Challenge.Citizens.API.Application.Entities
{
    public class Citizen
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
    }
}

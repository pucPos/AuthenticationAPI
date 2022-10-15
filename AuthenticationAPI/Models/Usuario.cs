using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AuthenticationAPI.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Nome { get; set; }

        public string Email { get; set; }
        public string Senha { get; set; }
    }
}

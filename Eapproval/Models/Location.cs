using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Eapproval.Models
{
    public class Location
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        [JsonPropertyName("_id")]
        public string? Id { get; set; }


        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}

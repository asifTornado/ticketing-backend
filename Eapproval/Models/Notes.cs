using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Eapproval.Models
{
    public class Notes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        [JsonPropertyName("_id")]
        public string? Id { get; set; } = null;


        [BsonElement("ticketId")]
        [JsonPropertyName("ticketId")]
        public string? TicketId { get; set; }


        [BsonElement("data")]
        [JsonPropertyName("data")]
        public string? Data { get; set; }

        [BsonElement("takenBy")]
        [JsonPropertyName("takenBy")]
        public string? TakenBy { get; set; }


        [BsonElement("date")]
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [BsonElement("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; } = "text";

        [BsonElement("files")]
        [JsonPropertyName("files")]
        public List<File2>? Files { get; set; } = null;

        [BsonElement("caption")]
        [JsonPropertyName("caption")]
        public string Caption { get; set; }


        [BsonElement("mentions")]
        [JsonPropertyName("mentions")]
        public List<User>? Mentions { get;set; } = null; 
    }
}

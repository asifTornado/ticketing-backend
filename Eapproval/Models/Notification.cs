using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Eapproval.Models
{
    public class Notification
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        [JsonPropertyName("_id")]
        public string Id { get; set; }


        [BsonElement("time")]
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [BsonElement("message")]
        [JsonPropertyName("message")]
        public string Message { get; set; }


        [BsonElement("ticketId")]
        [JsonPropertyName("ticketId")]
        public string TicketId { get; set; }



        [BsonElement("from")]
        [JsonPropertyName("from")]
        public User From { get; set; }


        [BsonElement("to")]
        [JsonPropertyName("to")]
        public User? To { get; set; } = null; 

        [BsonElement("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; } = "normal";


        [BsonElement("mentions")]
        [JsonPropertyName("mentions")]
        public List<User>? Mentions { get; set; } = null;



    }
}

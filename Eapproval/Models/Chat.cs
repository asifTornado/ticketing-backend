using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Eapproval.Models
{

    


    public class ConversationClass
    {
        [BsonElement("from")]
        [JsonPropertyName("from")]
        public User? From { get; set; }

        [BsonElement("message")]
        [JsonPropertyName("message")]
        public string? Message { get; set; }


        [BsonElement("files")]
        [JsonPropertyName("files")]
        public List<File2>? Files { get; set; } = new List<File2>();

        [BsonElement("time")]
        [JsonPropertyName("time")]
        public string? Time { get; set; } = null;

        [BsonElement("type")]
        [JsonPropertyName("type")]
        public string? Type { get; set; } = "text";
       

    }
    public class Chat
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        [BsonElement("_id")]
        public string? Id { get; set; } = null;


        [JsonPropertyName("ticketId")]
        [BsonElement("ticketId")]
        public string? TicketId { get; set; } = null;

        [BsonElement("conversation")]
        [JsonPropertyName("conversation")]
        public List<ConversationClass> Conversation { get; set; } = new List<ConversationClass>();


        [BsonElement("connectionHolder")]
        [JsonPropertyName("connectionHoler")]
        public List<ConnectionHolderClass> ConnectionHolders { get; set; } = new List<ConnectionHolderClass>();





       




  }

    public class ConnectionHolderClass
    {
        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [BsonElement("id")]
        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }

  
}

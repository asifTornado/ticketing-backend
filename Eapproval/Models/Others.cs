using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Eapproval.Models
{
   

    public class File2
    {
        [BsonElement("fileName")]
        [JsonPropertyName("fileName")]
        public string? FileName { get; set; }

        [BsonElement("originalName")]
        [JsonPropertyName("originalName")]
        public string? OriginalName { get; set; }
    }



    


   
    public enum ActionType
    {
        [EnumMember(Value = "TicketRaised")]  //0
        TicketRaised,
        
        [EnumMember(Value = "SupervisorApprove")] //1
        SupervisorApprove,

        [EnumMember(Value = "SeekingHigherApproval")] //2
        SeekingHigherApproval,

        [EnumMember(Value = "HigherApprove")] //3
        HigherApprove,

        [EnumMember(Value = "AssignSelf")] //4
        AssignSelf,

        [EnumMember(Value = "AssignOther")] //5
        AssignOther,

        [EnumMember(Value = "AskInfo")] //6
        AskInfo,

        [EnumMember(Value = "GiveInfo")] //7
        GiveInfo,

        [EnumMember(Value = "Reject")] //8
        Reject,

        [EnumMember(Value = "Reassign")] //9
        Reassign,

        [EnumMember(Value = "CloseRequest")] //10
        CloseRequest,

        [EnumMember(Value = "CloseRequestAccept")] //11
        CloseRequestAccept,


        [EnumMember(Value = "CloseRequestReject")] //12
        CloseRequestReject
    }



    public class ActionObject
    {
        [BsonElement("time")]
        [JsonPropertyName("time")]
        public string? Time { get; set; }

        [BsonElement("serial")]
        [JsonPropertyName("serial")]
        public int? Serial { get; set; } = 0;




        [BsonRepresentation(BsonType.String)]
        [BsonElement("type")]
        [JsonPropertyName("type")]
       
        public ActionType? Type { get; set; }

        [BsonElement("raisedBy")]
        [JsonPropertyName("raisedBy")]
        public User? RaisedBy { get; set; }

        [BsonElement("forwardedTo")]
        [JsonPropertyName("forwardedTo")]
        public User? ForwardedTo { get; set; }

        [BsonElement("comments")]
        [JsonPropertyName("comments")]
        public string? Comments { get; set; }




        [BsonElement("additionalInfo")]
        [JsonPropertyName("additionalInfo")]
        public string? AdditionalInfo { get; set; }


        [BsonElement("files")]
        [JsonPropertyName("files")]
        public List<File2?>? Files { get; set; }
    }


}

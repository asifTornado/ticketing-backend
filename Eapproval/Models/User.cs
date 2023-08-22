using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Eapproval.Models;


[BsonIgnoreExtraElements]
public class User
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [JsonPropertyName("_id")]
    [BsonElement("_id")]
    public string? Id { get; set; }

    [BsonElement("empName")]
    [JsonPropertyName("empName")]
    public string? EmpName { get; set; }


    [BsonElement("empCode")]
    [JsonPropertyName("empCode")]
    public string? EmpCode { get; set; }

    [BsonElement("designation")]
    [JsonPropertyName("designation")]
    public string? Designation { get; set; }

    [BsonElement("mailAddress")]
    [JsonPropertyName("mailAddress")]
    public string? MailAddress { get; set; }

    [BsonElement("unit")]
    [JsonPropertyName("unit")]
    public string? Unit { get; set; }

    [BsonElement("section")]
    [JsonPropertyName("section")]
    public string? Section { get; set; }

    [BsonElement("wing")]
    [JsonPropertyName("wing")]
    public string? Wing { get; set; }

    [BsonElement("team")]
    [JsonPropertyName("team")]
    public string? Team { get; set; }

    [BsonElement("groups")]
    [JsonPropertyName("groups")]
    public List<string>? Groups { get; set; }

    [BsonElement("department")]
    [JsonPropertyName("department")]
    public string? Department { get; set; }

    [BsonElement("TeamType")]
    [JsonPropertyName("TeamType")]
    public string? TeamType { get; set; }

    [BsonElement("password")]
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    
    [BsonElement("rank")]
    [JsonPropertyName("rank")]
    public int Rank { get; set; } = 2;

    [BsonElement("userType")]
    [JsonPropertyName("userType")]
    public string? UserType { get; set; } = "Not Available";

    [BsonElement("available")]
    [JsonPropertyName("available")]
    public bool? Available { get; set; } = true;

    [BsonElement("rating")]
    [JsonPropertyName("rating")]
    public int? Rating { get; set; } = 0;


    [BsonElement("raters")]
    [JsonPropertyName("raters")]
    public int? Raters { get; set; } = 0;


    [BsonElement("extension")]
    [JsonPropertyName("extension")]
    public string? Extension { get; set; } = "Not Available";



    [BsonElement("mobileNo")]
    [JsonPropertyName("mobileNo")]
    public string? mobileNo { get; set; } = "Not Available";


    [BsonElement("location")]
    [JsonPropertyName("location")]
    public string? Location { get; set; } = "Not Available";





}



public class DrawnSignatureClass
{
    [BsonElement("path")]
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [BsonElement("width")]
    [JsonPropertyName("width")]
    public string? Width { get; set; }


    [BsonElement("height")]
    [JsonPropertyName("height")]
    public string? Height { get; set; }


} 







using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using Org.BouncyCastle.Asn1.Mozilla;
using System.Security.Cryptography.Xml;

namespace Eapproval.Models;

public class Blogs
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    [JsonPropertyName("_id")]
    public string? Id { get; set; } = null;


    [BsonElement("authors")]
    [JsonPropertyName("authors")]
    public User? Authors { get; set; } = null;


    [BsonElement("content")]
    [JsonPropertyName("content")]
    public string? Content { get; set; } = null;


    [BsonElement("headline")]
    [JsonPropertyName("headline")]
    public string? Headline { get; set; } = null;


}

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel;

namespace Eapproval.Models

{

    public class DetailsClass
    {
        [BsonElement("label")]
        [JsonPropertyName("label")]
        public string? Label { get; set; } = "Not Available";


        [BsonElement("input")]
        [JsonPropertyName("input")]
        public string? Input { get; set; } = "Not Available";
    }

    

    public class TicketsProjected
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        [BsonElement("_id")]
        public string? Id { get; set; } = null;


        [BsonElement("number")]
        [JsonPropertyName("number")]
        public int Number { get; set; }



        [BsonElement("status")]
        [JsonPropertyName("status")]
        public string? Status { get; set; } = "Not Available";


        [BsonElement("requestDate")]
        [JsonPropertyName("requestDate")]
        public string? RequestDate { get; set; } = "Not Available";

        [BsonElement("currentHandlerName")]
        [JsonPropertyName("currentHandlerName")]
        public string? CurrentHandlerName { get; set; } = null;

        [BsonElement("currentHandlerEmail")]
        [JsonPropertyName("currentHandlerEmail")]
        public string? CurrentHandlerEmail { get; set; } = null;

        [BsonElement("raisedByName")]
        [JsonPropertyName("raisedByName")]
        public string? RaisedByName { get; set; } = null;

        [BsonElement("raisedByEmail")]
        [JsonPropertyName("raisedByEmail")]
        public string? RaisedByEmail { get; set; } = null;



        [BsonElement("problemDetails")]
        [JsonPropertyName("problemDetails")]
        public string? ProblemDetails { get; set; } = "Not Available";


    }


    
    [BsonIgnoreExtraElements]
    public class Tickets
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        [BsonElement("_id")]
        public string? Id { get; set; } = null;


        [BsonElement("number")]
        [JsonPropertyName("number")]
        public int Number { get; set; }

        [BsonElement("department")]
        [JsonPropertyName("department")]
        public string? Department { get; set; } = "Not Available";

        [BsonElement("problemDetails")]
        [JsonPropertyName("problemDetails")]
        public string? ProblemDetails { get; set; } = "Not Available";



        [BsonElement("assigned")]
        [JsonPropertyName("assigned")]
        public bool? Assigned { get; set; } = false;


        [BsonElement("hasService")]
        [JsonPropertyName("hasService")]
        public bool? HasService { get; set; } = false;


        [BsonElement("location")]
        [JsonPropertyName("location")]
        public string Location { get; set; }



        [BsonElement("phone")]
        [JsonPropertyName("phone")]
        public string Phone { get; set; }


        [BsonElement("extension")]
        [JsonPropertyName("extension")]
        public string? Extension { get; set; }


        [BsonElement("email")]
        [JsonPropertyName("email")]
        public string? Email { get; set; }



        [BsonElement("priority")]
        [JsonPropertyName("priority")]
        public string? Priority { get; set; }

        [BsonElement("approvalRequired")]
        [JsonPropertyName("approvalRequired")]
        public bool? ApprovalRequired { get; set; } = false;

        [BsonElement("raisedFor")]
        [JsonPropertyName("raisedFor")]
        public User? RaisedFor { get; set; } = new User();

        [BsonElement("remarks")]
        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; } = "Not Available";


        [BsonElement("closeRequested")]
        [JsonPropertyName("closeRequested")]
        public bool? CloseRequested { get; set; } = false;

        [BsonElement("supervisor")]
        [JsonPropertyName("supervisor")]
        public User? Supervisor { get; set; } = null;

        [BsonElement("assignedTo")]
        [JsonPropertyName("assignedTo")]
        public User? AssignedTo { get; set; } = null;

        [BsonElement("higherApprover")]
        [JsonPropertyName("higherApprover")]
       
        public User? HigherApprover { get; set; } = null;

        [BsonElement("files")]
        [JsonPropertyName("files")]
        public List<File2?> Files { get; set; } = new List<File2?>();

        [BsonElement("ticketType")]
        [JsonPropertyName("ticketType")]
        public string? TicketType { get; set; } = "Not Available";

        [BsonElement("raisedBy")]
        [JsonPropertyName("raisedBy")]
        public User? RaisedBy { get; set; } = new User();

        [BsonElement("status")]
        [JsonPropertyName("status")]
        public string? Status { get; set; } = "Not Available";



        [BsonElement("prevStatus")]
        [JsonPropertyName("prevStatus")]
        public string? PrevStatus { get; set; } = "Not Available";

        [BsonElement("ask")]
        [JsonPropertyName("ask")]
        public bool? Ask { get; set; } = false;

        [BsonElement("type")]
        [JsonPropertyName("type")]
        public string? Type { get; set; } = null;


        

        [BsonElement("infos")]
        [JsonPropertyName("infos")]
        public List<string>? Infos { get; set; } = new List<string>();

        [BsonElement("requestDate")]
        [JsonPropertyName("requestDate")]
        public string? RequestDate { get; set; } = "Not Available";

            [BsonElement("currentHandler")]
            [JsonPropertyName("currentHandler")]
            public User? CurrentHandler { get; set; } = new User();


          

        [BsonElement("ticketingHead")]
        [JsonPropertyName("ticketingHead")]
        public User? TicketingHead { get; set; } = null;

            [BsonElement("actions")]
            [JsonPropertyName("actions")]
            public List<ActionObject>? Actions { get; set; } = new List<ActionObject>();

        [BsonElement("prevHandler")]
        [JsonPropertyName("prevHandler")]
        public User? PrevHandler { get; set; } = new User();


        [BsonElement("serviceType")]
        [JsonPropertyName("serviceType")]
        public string? ServiceType { get; set; } = "Not Available";

            [BsonElement("groups")]
            [JsonPropertyName("groups")]
            public List<string?> Groups { get; set; } = new List<string?>();


        [BsonElement("madeCloseRequest")]
        [JsonPropertyName("madeCloseRequest")]
        public bool? MadeCloseRequest { get; set; } = false;


        [BsonElement("beenRejected")]
        [JsonPropertyName("beenRejected")]
        public bool? beenRejected { get; set; } = false;



        [BsonElement("accepted")]
        [JsonPropertyName("accepted")]
        public bool? Accepted { get; set; } = false;




        [BsonElement("details")]
        [JsonPropertyName("details")]
        public List<DetailsClass>? Details { get; set; } = null;


        [BsonElement("mentions")]
        [JsonPropertyName("mentions")]
        public List<User>? Mentions { get; set; } = null;



    }






}

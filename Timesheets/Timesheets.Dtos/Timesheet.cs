using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Timesheets.Dtos
{
    public class Timesheet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string CandidateName { get; set; }
        public string ClientName { get; set; }
        public string JobTitle { get; set; }
        public DateTime PlacementStartDate { get; set; }
        public DateTime PlacementEndDate { get; set; }
        public PlacementTypes PlacementType { get; set; } 
    }
}

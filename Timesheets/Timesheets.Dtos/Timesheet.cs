using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Timesheets.Dtos
{
    public class Timesheet
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public string CandidateName { get; set; }
        public string ClientName { get; set; }
        public string JobTitle { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local, DateOnly = true)]
        public DateTime PlacementStartDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local, DateOnly = true)]
        public DateTime PlacementEndDate { get; set; }
        public PlacementTypes PlacementType { get; set; } 
    }
}

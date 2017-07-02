using System;
using System.Collections.Generic;
using System.Text;

namespace Timesheets.Models
{
    public class Timesheet
    {
        public string Id { get; set; }
        public string CandidateName { get; set; }
        public string ClientName { get; set; }
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PlacementTypes PlacementType { get; set; } 
    }
}

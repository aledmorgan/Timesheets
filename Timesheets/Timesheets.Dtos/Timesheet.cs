using System;
using System.Collections.Generic;
using System.Text;

namespace Timesheets.Dtos
{
    public class Timesheet
    {
        public string CandidateName { get; set; }
        public string ClientName { get; set; }
        public string JobTitle { get; set; }
        public DateTime PlacementStartDate { get; set; }
        public DateTime PlacementEndDate { get; set; }
        public PlacementTypes PlacementType { get; set; } 
    }
}

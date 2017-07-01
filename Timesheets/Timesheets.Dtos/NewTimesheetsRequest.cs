using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesheets.Dtos
{
    public class NewTimesheetsRequest
    {
        public string Id { get; set; }
        public string CandidateName { get; set; }
        public string ClientName { get; set; }
        public string JobTitle { get; set; }
        public DateTime PlacementStartDate { get; set; }
        public DateTime PlacementEndDate { get; set; }
        public PlacementTypes PlacementType { get; set; }
    }
}

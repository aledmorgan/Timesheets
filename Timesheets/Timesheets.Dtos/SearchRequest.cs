using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesheets.Dtos
{
    public class SearchRequest
    {
        public string CandidateName { get; set; }
        public string ClientName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}

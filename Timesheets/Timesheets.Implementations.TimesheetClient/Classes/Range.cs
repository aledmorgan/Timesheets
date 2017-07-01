using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesheets.Implementations.TimesheetClient.Classes
{
    public class Range<T>
    {
        public T Start { get; set; }
        public T End { get; set; }
    }
}

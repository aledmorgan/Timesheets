using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesheets.Contracts
{
    public interface IDateHelper
    {
        IEnumerable<DateTime> GetDates(DateTime start, DateTime end);

        DateTime GetFirstDayOfMonth(DateTime date);

        DateTime GetLastDayOfMonth(DateTime date);

        DateTime GetFirstDayOfWeek(DateTime date);

        DateTime GetLastDayOfWeek(DateTime date);
    }
}

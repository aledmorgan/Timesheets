using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Contracts;

namespace Timesheets.Implementations.DateHelper
{
    public class DateHelper : IDateHelper
    {
        public IEnumerable<DateTime> GetDates(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new ArgumentException("Placement start date must be before the placement end date.");
            }

            while (start < end)
            {
                yield return start;
                start = start.AddDays(1);
            }
        }

        public DateTime GetFirstDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public DateTime GetLastDayOfMonth(DateTime date)
        {
            var firstDay = GetFirstDayOfMonth(date);
            return firstDay.AddMonths(1).AddDays(-1);
        }

        public DateTime GetFirstDayOfWeek(DateTime date)
        {
            var firstDay = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            var currentDay = date.Date;

            while (currentDay.DayOfWeek != firstDay)
            {
                currentDay = currentDay.AddDays(-1);
            }

            return currentDay;
        }

        public DateTime GetLastDayOfWeek(DateTime date)
        {
            var firstDay = GetFirstDayOfWeek(date);
            return firstDay.AddDays(6);
        }
    }
}

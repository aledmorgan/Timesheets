using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Contracts;
using Timesheets.Dtos;

namespace Timesheets.Implementations.TimesheetRepository
{
    public class TimesheetRepository : ITimesheetRepository
    {
        public Timesheet Create(Timesheet newTimesheet)
        {
            throw new NotImplementedException();
        }

        public Timesheet Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Timesheet Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Timesheet> GetAll()
        {
            throw new NotImplementedException();
        }

        public Timesheet Update(Timesheet updateTimesheet)
        {
            throw new NotImplementedException();
        }
    }
}

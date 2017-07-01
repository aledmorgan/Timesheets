using System;
using System.Collections.Generic;
using System.Text;
using Timesheets.Dtos;

namespace Timesheets.Contracts
{
    public interface ITimesheetRepository
    {
        Timesheet Get(int id);
        IEnumerable<Timesheet> GetAll();
        Timesheet Delete(int id);
        Timesheet Create(Timesheet newTimesheet);
        Timesheet Update(Timesheet updateTimesheet);
    }
}

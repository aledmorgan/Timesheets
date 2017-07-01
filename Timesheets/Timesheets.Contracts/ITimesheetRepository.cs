using System;
using System.Collections.Generic;
using System.Text;
using Timesheets.Dtos;

namespace Timesheets.Contracts
{
    public interface ITimesheetRepository
    {
        Timesheet Get(string id);
        IEnumerable<Timesheet> GetAll();
        void Delete(string id);
        void Insert(Timesheet newTimesheet);
        void InsertMany(IEnumerable<Timesheet> newTimesheets);
    }
}

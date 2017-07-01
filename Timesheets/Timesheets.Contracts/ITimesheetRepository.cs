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
        void Delete(int id);
        void Create(Timesheet newTimesheet);
    }
}

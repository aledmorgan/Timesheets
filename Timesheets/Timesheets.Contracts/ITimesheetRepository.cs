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
        IEnumerable<Timesheet> Search(SearchRequest request);
        void Delete(string id);
        void DeleteMany(IEnumerable<string> ids);
        void Insert(Timesheet newTimesheet);
        void InsertMany(IEnumerable<Timesheet> newTimesheets);
    }
}

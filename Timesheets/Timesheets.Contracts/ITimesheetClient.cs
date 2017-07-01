using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Contracts
{
    public interface ITimesheetClient
    {
        Timesheet Get(string id);
        IEnumerable<Timesheet> GetAll();
        bool Delete(string id);
        bool Create(Dtos.Timesheet newTimesheet);
    }
}

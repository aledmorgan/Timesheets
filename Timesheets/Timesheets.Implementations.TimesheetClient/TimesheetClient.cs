using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Contracts;
using Timesheets.Models;

namespace Timesheets.Implementations.TimesheetClient
{
    public class TimesheetClient : ITimesheetClient
    {
        private ITimesheetRepository _timesheetRepository;
        private AutoMapper.IMapper _mapper;

        public TimesheetClient(ITimesheetRepository timesheetRepository, AutoMapper.IMapper mapper)
        {
            _timesheetRepository = timesheetRepository;
            _mapper = mapper;
        }

        public bool Create(Dtos.Timesheet newTimesheet)
        {
            _timesheetRepository.Create(newTimesheet);

            return true;
        }

        public bool Delete(string id)
        {
            _timesheetRepository.Delete(id);

            return true;
        }

        public Timesheet Get(string id)
        {
            return _mapper.Map<Timesheet>(_timesheetRepository.Get(id));
        }

        public IEnumerable<Timesheet> GetAll()
        {
            return _mapper.Map<IEnumerable<Timesheet>>(_timesheetRepository.GetAll());
        }
    }
}

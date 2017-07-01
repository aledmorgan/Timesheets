using System;
using System.Collections.Generic;
using System.Globalization;
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
        private IDateHelper _dateHelper;

        public TimesheetClient(ITimesheetRepository timesheetRepository, AutoMapper.IMapper mapper, IDateHelper dateHelper)
        {
            _timesheetRepository = timesheetRepository;
            _mapper = mapper;
            _dateHelper = dateHelper;
        }

        public bool Create(Dtos.NewTimesheetsRequest newTimesheet)
        {
            var timesheets = GenerateTimesheetRequests(newTimesheet);
            _timesheetRepository.InsertMany(timesheets);

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

        private IEnumerable<Dtos.Timesheet> GenerateTimesheetRequests(Dtos.NewTimesheetsRequest request)
        {
            throw new NotImplementedException();
        }

        
    }
}

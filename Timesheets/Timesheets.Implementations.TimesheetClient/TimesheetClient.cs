using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Contracts;
using Timesheets.Implementations.TimesheetClient.Classes;
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
            if(request.PlacementType == Dtos.PlacementTypes.Weekly)
            {
                return GetWeeklyTimesheets(request);
            }else if(request.PlacementType == Dtos.PlacementTypes.Monthly)
            {
                return GetMonthlyTimesheets(request);
            }
            else
            {
                throw new ArgumentException("PlacementType must be Weekly or Monthly");
            }
        }

        private IEnumerable<Dtos.Timesheet> GetMonthlyTimesheets(Dtos.NewTimesheetsRequest request)
        {
            var startDate = request.PlacementStartDate.Day;
            var endDate = request.PlacementEndDate.Day;
            var startMonth = request.PlacementStartDate.Month;
            var endMonth = request.PlacementEndDate.Month;
            var startYear = request.PlacementStartDate.Year;
            var endYear = request.PlacementEndDate.Year;

            var ranges = new List<Range<DateTime>>();
            var timesheets = new List<Dtos.Timesheet>();

            while(startMonth <= endMonth && startYear <= endYear)
            {
                var rangeStart = new DateTime(startYear, startMonth, startDate);
                var rangeEnd = new DateTime(endYear, endMonth, endDate);
                var lastDay = _dateHelper.GetLastDayOfMonth(new DateTime(endYear, endMonth, endDate));

                if(lastDay.Day > rangeEnd.Day && lastDay.Month == rangeEnd.Month && lastDay.Year == rangeEnd.Year)
                {
                    rangeEnd = new DateTime(endYear, endMonth, lastDay.Day);
                }

                ranges.Add(new Range<DateTime>() { Start = rangeStart, End = rangeEnd });

                startMonth++;
                startDate = 1;

                if(startMonth > 12 && startYear < endYear)
                {
                    startMonth = 1;
                    startYear++;
                }
            }

            foreach(var range in ranges)
            {
                timesheets.Add(new Dtos.Timesheet()
                {
                    CandidateName = request.CandidateName,
                    ClientName = request.ClientName,
                    Id = request.Id,
                    JobTitle = request.JobTitle,
                    StartDate = range.Start,
                    EndDate = range.End,
                    PlacementType = request.PlacementType
                });
            }

            return timesheets;
        }

        private IEnumerable<Dtos.Timesheet> GetWeeklyTimesheets(Dtos.NewTimesheetsRequest request)
        {
            var start = request.PlacementStartDate;
            var end = request.PlacementEndDate;
            var ranges = new List<Range<DateTime>>();
            var timesheets = new List<Dtos.Timesheet>();
            var startReset = false;

            while(start < end)
            {
                var startRange = start;

                if (!startReset)
                {
                    var realStart = _dateHelper.GetFirstDayOfWeek(start);
                    start = realStart.AddDays(7);
                }
                else
                {
                    start = start.AddDays(7);
                }

                var endRange = startRange.AddDays(6);

                if(endRange > end)
                {
                    endRange = end;
                }

                ranges.Add(new Range<DateTime>() { Start = startRange, End = endRange });
            }

            foreach(var range in ranges)
            {
                timesheets.Add(new Dtos.Timesheet()
                {
                    CandidateName = request.CandidateName,
                    ClientName = request.ClientName,
                    Id = string.Empty,
                    JobTitle = request.JobTitle,
                    EndDate = range.End,
                    StartDate = range.Start,
                    PlacementType = request.PlacementType
                });
            }

            return timesheets;
        }
    }
}

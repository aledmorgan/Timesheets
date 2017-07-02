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
                var datebands = GetWeeklyDatebands(request);
                return GetTimesheetsFromDatebands(datebands, request);
            }else if(request.PlacementType == Dtos.PlacementTypes.Monthly)
            {
                var datebands = GetMonthlyDatebands(request);
                return GetTimesheetsFromDatebands(datebands, request);
            }
            else
            {
                throw new ArgumentException("PlacementType must be Weekly or Monthly");
            }
        }

        private IEnumerable<Range<DateTime>> GetMonthlyDatebands(Dtos.NewTimesheetsRequest request)
        {
            var start = request.PlacementStartDate;
            var end = request.PlacementEndDate;
            var startReset = false;
            var datebands = new List<Range<DateTime>>();

            while(start < end)
            {
                var datebandStart = start;

                if (!startReset)
                {
                    var startOfMonth = _dateHelper.GetFirstDayOfMonth(start);
                    start = startOfMonth.AddMonths(1);
                }
                else
                {
                    start = start.AddMonths(1);
                }

                var datebandEnd = start.AddDays(-1);

                if (datebandEnd > end)
                {
                    datebandEnd = end;
                }

                datebands.Add(new Range<DateTime>()
                {
                    Start = datebandStart,
                    End = datebandEnd
                });
            }

            return datebands;
        }

        private IEnumerable<Range<DateTime>> GetWeeklyDatebands(Dtos.NewTimesheetsRequest request)
        {
            var start = request.PlacementStartDate;
            var end = request.PlacementEndDate;
            var datebands = new List<Range<DateTime>>();
            var startReset = false;

            while(start < end)
            {
                var datebandStart = start;
                DateTime datebandEnd = DateTime.Now;

                if (!startReset)
                {
                    var startOfWeek = _dateHelper.GetFirstDayOfWeek(start);
                    start = startOfWeek.AddDays(7);

                    datebandEnd = start.AddDays(-1);
                }
                else
                {
                    start = start.AddDays(7);
                    datebandEnd = datebandStart.AddDays(6);
                }

                if(datebandEnd > end)
                {
                    datebandEnd = end;
                }

                datebands.Add(new Range<DateTime>()
                {
                    Start = datebandStart,
                    End = datebandEnd
                });
            }

            return datebands;
        }

        private IEnumerable<Dtos.Timesheet> GetTimesheetsFromDatebands(IEnumerable<Range<DateTime>> datebands, Dtos.NewTimesheetsRequest request)
        {
            var timesheets = new List<Dtos.Timesheet>();

            foreach (var dateband in datebands)
            {
                timesheets.Add(new Dtos.Timesheet()
                {
                    CandidateName = request.CandidateName,
                    ClientName = request.ClientName,
                    Id = string.Empty,
                    JobTitle = request.JobTitle,
                    EndDate = dateband.End,
                    StartDate = dateband.Start,
                    PlacementType = request.PlacementType
                });
            }

            return timesheets;
        }

        public bool DeleteTimesheets(IEnumerable<string> ids)
        {
            _timesheetRepository.DeleteMany(ids);
            return true;
        }

        public IEnumerable<Timesheet> Search(Dtos.SearchRequest request)
        {
            if(request.From == null || request.To == DateTime.MinValue)
            {
                request.From = new DateTime(1990,01,01);
            }

            if(request.To == null || request.To == DateTime.MinValue)
            {
                request.To = new DateTime(2100,01,01);
            }

            if(request.CandidateName == null)
            {
                request.CandidateName = string.Empty;
            }

            if(request.ClientName == null)
            {
                request.ClientName = string.Empty;
            }

            return _mapper.Map<IEnumerable<Timesheet>>(_timesheetRepository.Search(request));
        }
    }
}

using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Contracts;
using Timesheets.Implementations.DateHelper;
using Timesheets.Implementations.TimesheetClient;
using Timesheets.Implementations.TimesheetRepository;

namespace Timesheets.Ioc
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TimesheetRepository>().As<ITimesheetRepository>().SingleInstance();
            builder.RegisterType<TimesheetClient>().As<ITimesheetClient>().SingleInstance();
            builder.RegisterType<DateHelper>().As<IDateHelper>().SingleInstance();
        }
    }
}

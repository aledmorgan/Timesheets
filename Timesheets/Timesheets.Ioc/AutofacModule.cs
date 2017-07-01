﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Contracts;
using Timesheets.Implementations.TimesheetRepository;

namespace Timesheets.Ioc
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TimesheetRepository>().As<ITimesheetRepository>().SingleInstance();
        }
    }
}

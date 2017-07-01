using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Timesheets.Ioc;

namespace Timesheets.App_Start
{
    public class DIConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new AutofacModule());

            builder.RegisterControllers(typeof(MvcApplication).Assembly)
                .PropertiesAutowired();

            ConfigureMapping(builder);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void ConfigureMapping(ContainerBuilder builder)
        {
            MapperConfiguration config = ConfigureMapping();

            builder.Register(ctx => config.CreateMapper()).As<AutoMapper.IMapper>();
        }

        private static MapperConfiguration ConfigureMapping()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Dtos.Timesheet, Models.Timesheet>();
                cfg.CreateMap<Dtos.PlacementTypes, Models.PlacementTypes>();
            });
        }
    }
}
using Autofac;
using Autofac.Extras.DynamicProxy;
using Strategy_Pattern.Contracts;
using Strategy_Pattern.Enums;
using Strategy_Pattern.Services;
using Strategy_Pattern.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern
{
    class Startup
    {
        private static IContainer _container;

        public static IContainer Container
        {
            get { return _container; }
        }

        public static void IoCConfiguration()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<OnlyTheBestRealEstateStrategy>().Keyed<IPropertyMatcher>(AgencyCode.OTBRE).InstancePerLifetimeScope();
            builder.RegisterType<LocationRealEstateStrategy>().Keyed<IPropertyMatcher>(AgencyCode.LRE).InstancePerLifetimeScope();
            builder.RegisterType<ContraryRealEstateStrategy>().Keyed<IPropertyMatcher>(AgencyCode.CRE).InstancePerLifetimeScope();
            builder.RegisterType<PropertyMatchingService>().As<IPropertyMatchingService>().InstancePerLifetimeScope();

            builder.Register(c => new ExceptionLogger(Console.Out));
            builder.RegisterType<PropertyMatchingService>().As<IPropertyMatchingService>()
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(ExceptionLogger));

            _container = builder.Build();
        }
    }
}

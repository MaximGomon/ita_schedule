using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using ITA.Schedule.BLL;

namespace ITA.Schedule
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IContainer Container { get; private set; }

        internal static Assembly Assembly { get; private set; }

        protected void Start(Assembly executingAssembly)
        {
            MvcApplication.Assembly = executingAssembly;
            var builder = new ContainerBuilder();
            var assembly = typeof(MvcApplication).Assembly;
            builder.RegisterControllers(assembly);
            builder.RegisterFilterProvider();
            builder.RegisterModule(new WebModule());
            builder.RegisterModule(new BllModule());
            MvcApplication.Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));

        }

        protected virtual void Application_End()
        {
            ((IDisposable)MvcApplication.Container).Dispose();
        }
        protected void Application_Start()
        {
            Start(typeof(MvcApplication).Assembly);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }
    }
}

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
using ITA.Schedule.Logs.Filters;

namespace ITA.Schedule
{
    public class MvcApplication : System.Web.HttpApplication

    {
        //private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

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

        //protected virtual void Application_End()
        //{
        //    ((IDisposable)MvcApplication.Container).Dispose();
        //    logger.Info("Application End");
        //}
        protected void Application_Start()
        {
            Start(typeof(MvcApplication).Assembly);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalFilters.Filters.Add(new ErrorLogAttribute());

            //Logging
            //logger.Info("Application Start");
            //AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        //public void Init()
        //{
        //    logger.Info("Application Init");
        //}

        //public void Dispose()
        //{
        //    logger.Info("Application Dispose");
        //}

        //protected void Application_Error()
        //{
        //    logger.Info("Application Error");
        //}


    }
}

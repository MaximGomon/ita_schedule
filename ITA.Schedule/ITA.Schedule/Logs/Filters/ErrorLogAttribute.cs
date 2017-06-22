using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace ITA.Schedule.Logs.Filters
{
    public class ErrorLogAttribute: HandleErrorAttribute
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public override void OnException(ExceptionContext filterContext)
        {
            Log.Error(filterContext.Exception);
        }
    }
}
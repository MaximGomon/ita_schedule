using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace ITA.Schedule.Logs.Filters
{
    public class ActionLogAttribute: ActionFilterAttribute
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log.Info("ActionResult " + filterContext.ActionDescriptor.ActionName + " () is succesfull " +
                                      filterContext.Controller);

        }
    }
}
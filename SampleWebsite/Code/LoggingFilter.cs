using System;
using System.Web.Mvc;

namespace SampleWebsite.Code
{
    public class LoggingFilter : ActionFilterAttribute
    {
        public ILogger Logger { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            Logger.LogMessage("Yay!");
        }
    }
}
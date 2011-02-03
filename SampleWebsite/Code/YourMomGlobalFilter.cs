using System;
using System.Web.Mvc;

namespace SampleWebsite.Code
{
    public class YourMomGlobalFilter : IActionFilter
    {
        public YourMomGlobalFilter(IBar bar)
        {
            _bar = bar;
        }

        private IBar _bar;

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string message = String.Format("<!-- Your mom is so fat, she makes viewstate look lightweight. {0} -->", _bar.IPityTheFoo());
            filterContext.HttpContext.Response.Write(message);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //We won't do anything here.
        }
    }
}
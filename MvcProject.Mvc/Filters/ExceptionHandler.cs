using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Mvc.Filters
{
    public class ExceptionHandler
    {
        public class ExceptionHandlerAttribute: FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                var message = filterContext.Exception.Message;

                filterContext.Controller.ViewData.ModelState.AddModelError("CategoryException", message);

                filterContext.ExceptionHandled = true;

                filterContext.Result = new ViewResult
                {
                    ViewData = new ViewDataDictionary(filterContext.Controller.ViewData)
                };
            }
        }
    }
}
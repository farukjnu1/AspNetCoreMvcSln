using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreMvc.ActionFilters
{
    public class SchoolActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Log("OnActionExecuting", filterContext.RouteData);
            //Another filter has already returned a result so pass it on
            if (filterContext.Result != null) return;

            //Do your filtering
            var UserType = filterContext.HttpContext.Session.GetInt32("UserType");
            if (UserType != 2)
            {
                filterContext.Result = new RedirectResult("~/Home/Login");
            }

        }
    }
}

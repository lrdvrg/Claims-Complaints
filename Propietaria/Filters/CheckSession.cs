using Propietaria.Controllers;
using Propietaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Propietaria.Filters
{
    public class CheckSession : ActionFilterAttribute
    {
        private Users oUser;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            oUser = (Users)HttpContext.Current.Session["User"];
            if (oUser == null)
            {
                if (filterContext.Controller is LoginController == false)
                {
                    filterContext.HttpContext.Response.Redirect("/Login/Login");
                }
            }
        }
    }
}
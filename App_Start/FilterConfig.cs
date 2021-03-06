﻿using System.Web;
using System.Web.Mvc;

namespace MVCCourse2017
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Apply autherzation Globaly(Very Ristricted):
            filters.Add(new AuthorizeAttribute());

            //Apply Add HTTPS
            filters.Add(new RequireHttpsAttribute());
        }
    }
}

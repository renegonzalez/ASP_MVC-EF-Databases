﻿using System.Web;
using System.Web.Mvc;

namespace APP_WEB_MVC_LOCALDB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

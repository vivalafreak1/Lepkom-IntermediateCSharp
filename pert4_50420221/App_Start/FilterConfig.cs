﻿using System.Web;
using System.Web.Mvc;

namespace pert4_50420221
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
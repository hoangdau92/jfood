﻿using Core_MVC.Models;
using CS.Portal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Core_MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            jFoodEntities ctx = new jFoodEntities();
            var lh = ctx.JF_ThongTinLienHe.FirstOrDefault();
            Application["tenwebsite"] = lh.ten;
            Application["email"] = lh.email;
            Application["sodienthoai"] = lh.dienthoai;
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
            }

        }
    }
}
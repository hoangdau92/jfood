using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CS.Portal.Common
{
    public class BaseController : Controller
    {
        #region protected Variables
        protected bool HasPermission { get; private set; }
        protected string ControllerTitle { get; private set; }
        protected string ControllerAction { get; private set; }
        protected string ControllerName { get; private set; }

        #endregion
        #region Public Constructor Functions
        public BaseController()
        {
            HasPermission = false;
            ControllerTitle = string.Empty;
            ControllerName = string.Empty;
            ControllerAction = string.Empty;
        }
        #endregion
        protected override void Initialize(RequestContext requestContext)
        {
            try
            {
                base.Initialize(requestContext);
                RouteData routedata = requestContext.RouteData;
                object routes;
                if (routedata.Values.TryGetValue("MS_DirectRouteMatches", out routes))
                {
                    routedata = (routes as List<RouteData>).FirstOrDefault();
                }
                if (routedata == null)
                    return;
                Func<string, string> getValue = (s) =>
                {
                    object o;
                    return routedata.Values.TryGetValue(s, out o) ? o.ToString() : String.Empty;
                };
                this.ControllerAction = getValue("action");
                this.ControllerName = getValue("controller");
                //SetPermissions();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void SetPermissions()
        {
            try
            {
                ////Kiểm tra user login hay chưa?
                //CSF_MVCEntities MyContext = new CSF_MVCEntities();
                //CSF_Users_DAO objUserDao = new CSF_Users_DAO();
                //string username = HttpContext.User.Identity.Name;
                //List<int> listUserRole = objUserDao.GetRoleIDByUserName(username);
                //string ControllerAction = this.ControllerName + "-" + this.ControllerAction;
                //var ListPermission = (from a in MyContext.CSF_RoleFunction
                //                      join b in MyContext.CSF_Functions on a.FunctionID equals b.ID
                //                      where listUserRole.Contains(a.RoleID)
                //                      select new { ca = b.Controller_Action.Trim() }).ToList();
                //var permission = ListPermission.Where(x => x.ca.Contains(ControllerAction.Trim())).FirstOrDefault();
                //if (permission != null)
                //{
                //    this.HasPermission = true;
                //}
                //else
                //{
                //    this.HasPermission = false;
                //}
                //return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        ////Set Alert
        protected void SetAlert(string message, string type)
        {
            @TempData["AlertMessage"] = message;
            if (type.ToLower().Trim() == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type.ToLower().Trim() == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type.ToLower().Trim() == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }

    }
}
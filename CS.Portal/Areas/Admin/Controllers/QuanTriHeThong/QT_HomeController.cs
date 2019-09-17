using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS.Portal.Common;
using CS.Portal.Core.EF;
using CS.Portal.Core.DAO;
using CS.Portal.App_Start;

namespace Core_MVC.Areas.Admin.Controllers
{
    public class QT_HomeController : BaseController
    {
        //
        // GET: /Admin/Home/

        [CheckPermission]
        public ActionResult Index()
        {
            return View();
        }

        #region MENU
        public PartialViewResult AdminMenu()
        {
            try
            {
                CSF_MVCEntities entities = new CSF_MVCEntities();
                CSF_Users_DAO objUserDao = new CSF_Users_DAO();
                string username = HttpContext.User.Identity.Name;
                int intGuestGroup = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["IDGuestGroup"]);
                List<int> lRoleID = objUserDao.GetRoleIDByUserName(username, intGuestGroup);
                string stringRoleID = String.Join(",", lRoleID);
                //
                List<CSF_Pages> listAllPage = new List<CSF_Pages>();
                if (username.Trim().ToLower() != "host")
                {
                    var lPageActiveID = entities.CSF_Pages_GetPageByRoleID(stringRoleID).Select(x => (int)x.id).ToList();
                    listAllPage = entities.CSF_Pages.Where(x => lPageActiveID.Contains(x.ID) && x.IsAdmin == true).OrderBy(x => x.Order).ToList();
                }
                else
                {
                    listAllPage = entities.CSF_Pages.Where(x => x.IsAdmin == true && x.IsBlank == false && x.IsActive == true).OrderBy(x => x.Order).ToList();
                }
                //
                string stringMenu = buildTreeMenu(listAllPage);
                MainMenu mainMenu = new MainMenu();
                mainMenu.stringMenu = stringMenu;
                return PartialView(mainMenu);
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                return PartialView();
            }
        }

        private string buildTreeMenu(List<CSF_Pages> listAllPage)
        {
            try
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["SiteUrl"] + "/admin/";
                url = url.ToLower();
                string stringMenu = "<ul class='nav' id='side-menu' aria-expanded='true'>";
                stringMenu += "<li><a href='" + url.Replace("/admin", "") + "' target='_blank'><i class='fas fa-home'></i> Về trang chủ</a></li>";
                var parentPage = listAllPage.Where(x => x.ParentID == 0).ToList();
                int level = 1;
                foreach (var page in parentPage)
                {
                    level = 1;
                    var childPage = listAllPage.Where(x => x.ParentID == page.ID).ToList();
                    if (childPage.Any())
                    {
                        stringMenu += "<li>";
                        stringMenu += "<a href='" + url + page.Key + "'>" + page.Icon + ' ' + page.Name + " <span class='fa arrow'></span></a>";
                        stringMenu += getSubMenu(childPage, listAllPage, url, level);
                        stringMenu += "</li>";
                    }
                    else
                    {
                        stringMenu += "<li><a href='" + url + page.Key + "'>" + page.Icon + ' ' + page.Name + "</a></li>";
                    }
                }
                stringMenu += "</ul>";
                return stringMenu;
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                throw;
            }
        }

        private string getSubMenu(List<CSF_Pages> childPage, List<CSF_Pages> listAllPage, string url, int level)
        {
            try
            {
                level++;
                string submenu = "";
                if (level == 2)
                {
                    submenu += "<ul class='nav nav-second-level collapse in' aria-expanded='true'>";
                }
                else
                {
                    submenu += "<ul class='nav nav-third-level collapse' aria-expanded='true'>";
                }
                foreach (var page in childPage)
                {
                    var xChildPage = listAllPage.Where(x => x.ParentID == page.ID).ToList();
                    if (xChildPage.Any())
                    {
                        submenu += "<li>";
                        submenu += "<a href='" + url + page.Key + "'>" + page.Icon + ' ' + page.Name + " <span class='fa arrow'></span></a>";
                        submenu += getSubMenu(xChildPage, listAllPage, url, level);
                        submenu += "</li>";
                    }
                    else
                    {
                        submenu += "<li><a href='" + url + page.Key + "'>" + page.Icon + ' ' + page.Name + "</a></li>";
                    }
                }
                submenu += "</ul>";
                return submenu;
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                throw ex;
            }
        }
        #endregion
    }
}

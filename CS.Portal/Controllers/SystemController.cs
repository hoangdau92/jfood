using CS.Portal.Common;
using CS.Portal.Core.DAO;
using CS.Portal.Core.EF;
using Core_MVC.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core_MVC.Models;

namespace Core_MVC.Controllers
{
    public class SystemController : BaseController
    {
        //
        // GET: /System/

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult MainMenu()
        {
            try
            {
                int intGuestGroup = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["IDGuestGroup"]);
                CSF_MVCEntities entities = new CSF_MVCEntities();
                CSF_Users_DAO objUserDao = new CSF_Users_DAO();
                string username = HttpContext.User.Identity.Name;
                List<int> lRoleID = objUserDao.GetRoleIDByUserName(username, intGuestGroup);
                string stringRoleID = String.Join(",", lRoleID);
                //
                List<CSF_Pages> listAllPage = new List<CSF_Pages>();
                if (username.Trim().ToLower() != "host")
                {
                    var lPageActiveID = entities.CSF_Pages_GetPageByRoleID(stringRoleID).Select(x => (int)x.id).ToList();
                    listAllPage = entities.CSF_Pages.Where(x => lPageActiveID.Contains(x.ID) && x.IsAdmin == false).OrderBy(x => x.Order).ToList();
                }
                else
                {
                    listAllPage = entities.CSF_Pages.Where(x => x.IsAdmin == false && x.IsBlank == false && x.IsActive == true).OrderBy(x => x.Order).ToList();
                }
                //
                int sanphamtronggio = 0;
                if (Session["cart"] != null)
                {
                    List<ShoppingCart> lCart = (List<ShoppingCart>)Session["cart"];
                    sanphamtronggio = lCart.Count();
                }
                string stringMenu = buildTreeMenu(listAllPage, sanphamtronggio);
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

        private string buildTreeMenu(List<CSF_Pages> listAllPage, int sanphamtronggio)
        {
            try
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["SiteUrl"] + "/";
                string stringMenu = "<ul class='navbar-nav ml-auto'>";
                var parentPage = listAllPage.Where(x => x.ParentID == 0).ToList();
                string rootKey = "";
                int rootID = 0;
                foreach (var page in parentPage)
                {
                    var childPage = listAllPage.Where(x => x.ParentID == page.ID).ToList();
                    if (childPage.Any())
                    {
                        rootKey = page.Key;
                        rootID = page.ID;
                        stringMenu += "<li class='nav-item dropdown'>";
                        stringMenu += "<a class='nav-link dropdown-toggle' data-toggle='dropdown' href='" + url + rootKey + "' aria-haspopup='true' aria-expanded='false'>" + page.Name + "</a>";
                        stringMenu += getSubMenu(childPage, listAllPage, rootKey, url);
                        stringMenu += "</li>";
                    }
                    else
                    {
                        stringMenu += "<li class='nav-item active'><a class='nav-link' href='" + url + page.Key + "'>" + page.Name + "</a></li>";
                    }
                }
                stringMenu += "<li class='nav-item cta cta-colored'><a href='" + url + "gio-hang" + "' class='nav-link'><span class='icon-shopping_cart'></span>[<span id='ghsoluong'>" + sanphamtronggio + "</span>]</a></li>";
                stringMenu += "</ul>";
                return stringMenu;
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                throw;
            }
        }

        private string getSubMenu(List<CSF_Pages> childPage, List<CSF_Pages> listAllPage, string rootKey, string url)
        {
            try
            {
                string submenu = "<div class='dropdown-menu' aria-labelledby='dropdown04'>";
                foreach (var page in childPage)
                {
                    submenu += "<a class='dropdown-item' href='#'>" + page.Name + "</a>";
                }
                submenu += "</div>";
                return submenu;
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                throw ex;
            }
        }

        public PartialViewResult Footer()
        {
            try
            {
                jFoodEntities ctx = new jFoodEntities();
                var lh = ctx.JF_ThongTinLienHe.FirstOrDefault();
                return PartialView(lh);
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                return PartialView();
            }
        }

        public PartialViewResult Banner(string title)
        {
            try
            {
                ViewBag.TITLE = title;
                return PartialView();
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                return PartialView();
            }
        }

    }
}

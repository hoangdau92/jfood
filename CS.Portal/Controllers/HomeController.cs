using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS.Portal.Core.DAO;
using CS.Portal.Core.EF;
using CS.Portal.Common;
using System.Web.Security;
using Core_MVC.Areas.Admin.Controllers;
using System.Data;
using Core_MVC.Models;

namespace Core_MVC.Controllers
{
    public class HomeController : BaseController
    {
        jFoodEntities ctx = new jFoodEntities();
        public ActionResult Index()
        {
            var sanphamhot = ctx.JF_SanPham.Where(x => x.kichhoat == true && x.hientrangchu == true).ToList();
            ViewBag.URLIMAGE = System.Configuration.ConfigurationManager.AppSettings["UrlImage"];
            return View(sanphamhot);
        }


        

        public PartialViewResult DangNhap(string title)
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

        public PartialViewResult UnderConstruction(string title)
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

        public PartialViewResult _Blank(string title)
        {
            try
            {
                return PartialView();
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                return PartialView();
            }
        }


        public PartialViewResult Slider(string title)
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

        public PartialViewResult LoaiSanPham(string title)
        {
            try
            {
                var lsp = ctx.JF_LoaiSanPham.Where(x => x.kichhoat == true).OrderBy(x => x.thutu).ToList();
                ViewBag.TITLE = title;
                return PartialView(lsp);
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                return PartialView();
            }
        }


    }
}

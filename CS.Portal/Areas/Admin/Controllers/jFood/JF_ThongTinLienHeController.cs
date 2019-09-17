using Core_MVC.Models;
using CS.Portal.App_Start;
using CS.Portal.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core_MVC.Areas.Admin.Controllers.jFood
{
    public class JF_ThongTinLienHeController : BaseController
    {
        jFoodEntities ctx = new jFoodEntities();
        //
        // GET: /Admin/JF_ThongTinLienHe/
        [CheckPermission]
        public ActionResult Index()
        {
            var tt = ctx.JF_ThongTinLienHe.FirstOrDefault();
            return View(tt);
        }


        [CheckPermission]
        [HttpPost]
        public ActionResult Index(FormCollection fc, JF_ThongTinLienHe obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ctx.Entry(obj).State = EntityState.Modified;
                    int cn = ctx.SaveChanges();
                    if (cn > 0)
                    {
                        SetAlert("Cập nhật thành công", AlertType.Success);
                        return RedirectToAction("Index", "JF_ThongTinLienHe");
                    }
                    else
                    {
                        SetAlert("Cập nhật không thành công", AlertType.Error);
                    }

                }
                return View(obj);
            }
            catch (Exception ex)
            {
                SetAlert("Lỗi" + ex.Message.ToString(), AlertType.Error);
                Logs.WriteLog(ex);
                return View();
            }
        }

    }
}

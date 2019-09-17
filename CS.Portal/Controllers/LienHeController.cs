using Core_MVC.Models;
using CS.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core_MVC.Controllers
{
    public class LienHeController : BaseController
    {
        //
        // GET: /GioiThieu/

        public ActionResult Index()
        {
            using (jFoodEntities ctx = new jFoodEntities())
            {
                var lh = ctx.JF_ThongTinLienHe.FirstOrDefault();
                if (lh != null)
                {
                    return View(lh);
                }
                return View();
            }
        }

    }
}

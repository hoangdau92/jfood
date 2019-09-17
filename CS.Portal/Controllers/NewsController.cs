using CS.Portal.Common;
using CS.Portal.Core.DAO;
using CS.Portal.Core.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Core_MVC.Controllers
{
    public class NewsController : BaseController
    {
        //
        // GET: /News/

        public ActionResult Index(string category, int? page)
        {
            CSF_MVCEntities ctx = new CSF_MVCEntities();
            var cate = ctx.CMS_Categories.Where(x => x.KEY == category).FirstOrDefault();
            ViewBag.CATE = cate.NAME;
            var data = ctx.CMS_News_LayTatCa(cate.ID, "", 5).ToList();
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(data.ToPagedList(pageNumber, pageSize));
        }

        public PartialViewResult ChiTietTinTuc(string id)
        {
            try
            {
                int newsid = Convert.ToInt32(id);
                CSF_MVCEntities MyContext = new CSF_MVCEntities();
                var news = MyContext.CMS_News.Find(newsid);
                if (news != null)
                {
                    int cateid = (int)news.ID_CATEGORIES;
                    var cate = MyContext.CMS_Categories.Find(cateid);
                    string catekey = cate.KEY;
                    ViewBag.CateName = cate.NAME;
                }
                return PartialView(news);
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                return PartialView();
            }
        }

        public PartialViewResult TinTrangChu()
        {
            try
            {
                CSF_MVCEntities MyContext = new CSF_MVCEntities();
                var news = MyContext.CMS_News_LayTinBaiCongKhaiTheoCateKey("tin-hoat-dong").Take(3).ToList();
                return PartialView(news);
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                return PartialView();
            }
        }

        public PartialViewResult BaiTuVan()
        {
            try
            {
                CSF_MVCEntities MyContext = new CSF_MVCEntities();
                ViewBag.CONTENT = MyContext.CMS_News.FirstOrDefault(x=>x.ID == 551).CONTENTS;
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

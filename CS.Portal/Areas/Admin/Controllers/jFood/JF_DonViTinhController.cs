using Core_MVC.Models;
using CS.Portal.App_Start;
using CS.Portal.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core_MVC.Areas.Admin.Controllers
{
    public class JF_DonViTinhController : BaseController
    {
        jFoodEntities ctx = new jFoodEntities();
        //
        // GET: /Admin/JF_DonViTinh/
        [CheckPermission]
        public ActionResult Index(string keyword, int? page)
        {
            try
            {
                keyword = keyword != null ? keyword.Trim() : "";
                var data = ctx.JF_DonViTinh.Where(x => x.ten.Contains(keyword) && x.kichhoat == true).OrderBy(x => x.ten).ToList();
                ViewBag.SearchString = keyword;
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(data.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                SetAlert("Lỗi" + ex.Message.ToString(), "error");
                Logs.WriteLog(ex);
                return View();
            }
        }

        [CheckPermission]
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                SetAlert("Lỗi" + ex.Message.ToString(), AlertType.Error);
                Logs.WriteLog(ex);
                return View();
            }
        }

        [CheckPermission]
        [HttpPost]
        public ActionResult Create(FormCollection fc, JF_DonViTinh obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dvt = ctx.JF_DonViTinh.Where(x => x.ten == obj.ten && x.kichhoat == true).FirstOrDefault();
                    if (dvt != null)
                    {
                        ModelState.AddModelError("", "Đã tồn tại đơn vị tính này !");
                        return View();
                    }
                    obj.kichhoat = true;
                    ctx.JF_DonViTinh.Add(obj);
                    ctx.SaveChanges();
                    if (obj.id > 0)
                    {
                        SetAlert("Thêm mới loại sản phẩm thành công", AlertType.Success);
                        return RedirectToAction("Index", "JF_DonViTinh");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm mới không thành công");
                    }
                    return View("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                SetAlert("Lỗi" + ex.Message.ToString(), AlertType.Error);
                Logs.WriteLog(ex);
                return View();
            }
        }

        [CheckPermission]
        public ActionResult Edit(int id)
        {
            try
            {
                var obj = ctx.JF_DonViTinh.Find(id);
                if (obj != null)
                {
                    return View(obj);
                }
                return View();
            }
            catch (Exception ex)
            {
                SetAlert("Lỗi" + ex.Message.ToString(), AlertType.Error);
                Logs.WriteLog(ex);
                return View();
            }
        }


        [CheckPermission]
        [HttpPost]
        public ActionResult Edit(FormCollection fc, JF_DonViTinh obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var o = ctx.JF_DonViTinh.Where(x => x.ten.ToLower() == obj.ten.ToLower() && x.kichhoat == true).FirstOrDefault();
                    if (o.id != obj.id)
                    {
                        ModelState.AddModelError("", "Đã tồn tại dvt này !");
                        return View();
                    }
                    o.ten = obj.ten;
                    o.mota = obj.mota;
                    ctx.Entry(o).State = EntityState.Modified;
                    int cn = ctx.SaveChanges();
                    if (cn > 0)
                    {
                        SetAlert("Cập nhật thành công", AlertType.Success);
                        return RedirectToAction("Index", "JF_DonViTinh");
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

        [CheckPermission]
        public JsonResult Delete(int id)
        {
            try
            {
                var obj = ctx.JF_DonViTinh.Find(id);
                if (obj != null)
                {
                    obj.kichhoat = false;
                    ctx.Entry(obj).State = EntityState.Modified;
                    ctx.SaveChanges();
                    SetAlert("Xóa thành công", AlertType.Success);
                    return Json(new { status = true, message = "" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { status = false, message = "Lỗi xóa bản ghi." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                return Json(new { status = false, message = "Lỗi: " + ex }, JsonRequestBehavior.AllowGet);
            }
        }
    }

}


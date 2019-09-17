using Core_MVC.Models;
using CS.Portal.App_Start;
using CS.Portal.Common;
using PagedList;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Core_MVC.Areas.Admin.Controllers
{
    public class JF_SanPhamController : BaseController
    {
        jFoodEntities ctx = new jFoodEntities();
        //
        // GET: /Admin/JF_SanPham/
        [CheckPermission]
        public ActionResult Index(string key, int? loaisanpham, int? page)
        {
            try
            {
                TempData["loaisanpham"] = ctx.JF_LoaiSanPham.Where(x => x.kichhoat == true).OrderBy(x => x.thutu).ToList();
                TempData.Keep("loaisanpham");
                key = key != null ? key.Trim() : "";
                loaisanpham = (loaisanpham ?? -1);
                ViewBag.LOAISANPHAM = loaisanpham;
                var data = ctx.JF_SanPham.Where(x => x.ten.Contains(key) && x.kichhoat == true && (x.id_loaisanpham == loaisanpham || loaisanpham == -1)).OrderBy(x => x.ten).ToList();
                ViewBag.SearchString = key;
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
                TempData["loaisanpham"] = ctx.JF_LoaiSanPham.Where(x => x.kichhoat == true).OrderBy(x => x.thutu).ToList();
                TempData.Keep("loaisanpham");
                TempData["donvitinh"] = ctx.JF_DonViTinh.Where(x => x.kichhoat == true).OrderBy(x => x.ten).ToList();
                TempData.Keep("donvitinh");
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
        public ActionResult Create(FormCollection fc, JF_SanPham obj)
        {
            try
            {
                TempData.Keep("loaisanpham");
                TempData.Keep("donvitinh");
                if (ModelState.IsValid)
                {
                    obj.hientrangchu = obj.hientrangchu == null ? false : true;
                    obj.noibat = obj.noibat == null ? false : true;
                    obj.kichhoat = true;
                    obj.ngaycapnhat = DateTime.Now;
                    ctx.JF_SanPham.Add(obj);
                    ctx.SaveChanges();
                    if (obj.id > 0)
                    {
                        SetAlert("Thêm mới sản phẩm thành công", AlertType.Success);
                        return RedirectToAction("Index", "JF_SanPham");
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
                ViewBag.URLIMAGE = System.Configuration.ConfigurationManager.AppSettings["UrlImage"];
                TempData["loaisanpham"] = ctx.JF_LoaiSanPham.Where(x => x.kichhoat == true).OrderBy(x => x.thutu).ToList();
                TempData.Keep("loaisanpham");
                TempData["donvitinh"] = ctx.JF_DonViTinh.Where(x => x.kichhoat == true).OrderBy(x => x.ten).ToList();
                TempData.Keep("donvitinh");
                var obj = ctx.JF_SanPham.Find(id);
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
        public ActionResult Edit(FormCollection fc, JF_SanPham obj)
        {
            try
            {
                TempData.Keep("loaisanpham");
                TempData.Keep("donvitinh");
                if (ModelState.IsValid)
                {
                    var o = ctx.JF_SanPham.Find(obj.id);
                    o.ten = obj.ten;
                    o.giatruockm = obj.giatruockm;
                    o.giatien = obj.giatien;
                    o.id_donvitinh = obj.id_donvitinh;
                    o.id_loaisanpham = obj.id_loaisanpham;
                    o.hinhdaidien = obj.hinhdaidien;
                    o.hientrangchu = obj.hientrangchu == null ? false : true;
                    o.noibat = obj.noibat == null ? false : true;
                    o.mota = obj.mota;
                    ctx.Entry(o).State = EntityState.Modified;
                    int cn = ctx.SaveChanges();
                    if (cn > 0)
                    {
                        SetAlert("Cập nhật thành công", AlertType.Success);
                        return RedirectToAction("Index", "JF_SanPham");
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
                var obj = ctx.JF_SanPham.Find(id);
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

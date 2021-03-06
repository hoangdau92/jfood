﻿using Core_MVC.Models;
using CS.Portal.App_Start;
using CS.Portal.Common;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using System;
using System.Data.Entity;

namespace Core_MVC.Areas.Admin.Controllers.jFood
{
    public class JF_DonHangController : BaseController
    {
        jFoodEntities ctx = new jFoodEntities();
        //
        // GET: /Admin/JF_DonHang/
        [CheckPermission]
        public ActionResult Index(string ma, int? trangthai, string tungay, string denngay, int? page)
        {
            XoaDonHangThua();
            ma = ma != null ? ma.Trim() : "";
            trangthai = trangthai ?? -1;
            ViewBag.TRANGTHAI = trangthai;
            DateTime temp;
            var data = ctx.JF_DonHang.Where(x => x.madonhang.Contains(ma) && x.kichhoat == true && (x.trangthai == trangthai || trangthai == -1)).OrderBy(x => x.ngaydathang).ToList();
            if (tungay != null && tungay != "")
            {
                temp = Convert.ToDateTime(tungay);
                data = data.Where(x => x.ngaydathang >= temp).ToList();
                ViewBag.TUNGAY = temp.ToString("dd-MM-yyyy");
            }
            if (denngay != null && denngay != "")
            {
                temp = Convert.ToDateTime(denngay);
                data = data.Where(x => x.ngaydathang <= temp.AddDays(1)).ToList();
                ViewBag.DENNGAY = temp.ToString("dd-MM-yyyy");
            }
            ViewBag.MA = ma;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(data.ToPagedList(pageNumber, pageSize));
        }

        private void XoaDonHangThua()
        {
            var dhs = ctx.JF_DonHang.Where(x => x.JF_SanPham_DonHang.Count() <= 0);
            if (dhs != null && dhs.Count() > 0)
            {
                foreach (var item in dhs)
                {
                    ctx.JF_DonHang.Remove(item);
                }
                ctx.SaveChanges();
            }
        }

        [CheckPermission]
        public ActionResult Details(int id)
        {
            try
            {
                var donhang = ctx.JF_DonHang.Where(x => x.id == id && x.kichhoat == true).FirstOrDefault();
                if (donhang != null)
                {
                    return View(donhang);
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
        public ActionResult Details(FormCollection fc, int id, string motaxuly)
        {
            try
            {
                var o = ctx.JF_DonHang.Find(id);
                if (ModelState.IsValid)
                {
                    o.trangthai = o.trangthai == 1 ? 0 : 1;
                    o.motaxuly = motaxuly;
                    ctx.Entry(o).State = EntityState.Modified;
                    int cn = ctx.SaveChanges();
                    if (cn > 0)
                    {
                        SetAlert("Cập nhật thành công", AlertType.Success);
                    }
                    else
                    {
                        SetAlert("Cập nhật không thành công", AlertType.Error);
                    }

                }
                return View(o);
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

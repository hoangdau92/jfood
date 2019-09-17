using Core_MVC.Models;
using CS.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core_MVC.Controllers
{
    public class GioHangController : BaseController
    {
        //
        // GET: /GioHang/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DonDatHang()
        {
            ViewBag.MADONHANG = "DH" + ConvertToUnixTime(DateTime.Now).ToString();
            using (jFoodEntities ctx = new jFoodEntities())
            {
                TempData["htthanhtoan"] = ctx.JF_HinhThucThanhToan.Where(x => x.kichhoat == true).ToList();
                TempData.Keep("htthanhtoan");
            }
            return View();
        }

        public ActionResult Success()
        {
            using (jFoodEntities ctx = new jFoodEntities())
            {
                //var dh = ctx.JF_DonHang.Find(2);
                //TempData["donhang"] = dh;
                //SetAlert("Đơn hàng " + dh.madonhang + " được tạo thành công!<br/> Vui lòng ghi nhớ mã số đơn hàng. Chúng tôi sẽ liên lạc lại với bạn trong thời gian sớm nhất.", AlertType.Success);
                if (TempData["donhang"] == null)
                {
                    return RedirectToAction("", "giohang");
                }
                var donhang = (JF_DonHang)TempData["donhang"];
                var lSP = ctx.JF_LaySanPhamTheoDonHang(donhang.id).ToList();
                return View(lSP);
            }
        }

        public long ConvertToUnixTime(DateTime datetime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return (long)(datetime - sTime).TotalSeconds;
        }

        [HttpPost]
        public ActionResult DonDatHang(FormCollection fc, JF_DonHang obj)
        {
            try
            {
                TempData.Keep("htthanhtoan");
                ViewBag.MADONHANG = "DH" + ConvertToUnixTime(DateTime.Now).ToString();
                if (Session["cart"] == null)
                {
                    SetAlert("Chưa có sản phẩm nào trong giỏ hàng! ", AlertType.Error);
                    return View();
                }
                if (ModelState.IsValid)
                {
                    using (jFoodEntities ctx = new jFoodEntities())
                    {
                        List<ShoppingCart> lCart = (List<ShoppingCart>)Session["cart"];
                        obj.kichhoat = true;
                        obj.trangthai = 0;
                        obj.ngaydathang = DateTime.Now;
                        ctx.JF_DonHang.Add(obj);
                        ctx.SaveChanges();
                        decimal thanhtien = 0;
                        foreach (var item in lCart)
                        {
                            JF_SanPham_DonHang sp_dh = new JF_SanPham_DonHang();
                            sp_dh.id_donhang = obj.id;
                            sp_dh.id_sanpham = item.idsanpham;
                            sp_dh.soluong = item.soluong;
                            sp_dh.kichhoat = true;
                            sp_dh.giatien = item.giatien;
                            thanhtien = item.soluong * item.giatien;
                            sp_dh.thanhtien = thanhtien;
                            ctx.JF_SanPham_DonHang.Add(sp_dh);
                        }
                        ctx.SaveChanges();
                        Session["cart"] = null;
                    }
                    SetAlert("Đơn hàng " + obj.madonhang + " được tạo thành công!<br/> Vui lòng ghi nhớ mã số đơn hàng. Chúng tôi sẽ liên lạc lại với bạn trong thời gian sớm nhất.", AlertType.Success);
                    TempData["donhang"] = obj;
                    return RedirectToAction("success", "GioHang");
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

    }
}

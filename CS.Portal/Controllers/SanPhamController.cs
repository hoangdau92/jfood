using Core_MVC.Models;
using CS.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core_MVC.Controllers
{
    public class SanPhamController : BaseController
    {
        jFoodEntities ctx = new jFoodEntities();
        //
        // GET: /SanPham/

        public ActionResult Index(int? id)
        {
            id = id ?? 0;
            var lsp = ctx.JF_LoaiSanPham.FirstOrDefault(x => x.id == id);
            ViewBag.LOAISANPHAM = lsp == null ? "" : lsp.ten;
            var data = ctx.JF_SanPham.Where(x => (x.id_loaisanpham == id || id == 0) && x.kichhoat == true).OrderBy(x => x.ten).ToList();

            TempData["spnoibat"] = data.Where(x => x.noibat == true).ToList();
            TempData.Keep("spnoibat");

            return View(data);
        }

        public JsonResult addtocart(int idsanpham, int quantity)
        {
            try
            {
                int soluong = 0;
                var sp = ctx.JF_SanPham.Find(idsanpham);
                if (sp == null)
                {
                    return Json(new { status = false, message = "Oops! Lỗi cơ sở dữ liệu" }, JsonRequestBehavior.AllowGet);
                }
                if (Session["cart"] == null)
                {
                    List<ShoppingCart> lCart = new List<ShoppingCart>();
                    lCart.Add(new ShoppingCart { idsanpham = idsanpham, donvitinh = sp.JF_DonViTinh.ten, giatien = (decimal)sp.giatien, loaisanpham = sp.JF_LoaiSanPham.ten, tensanpham = sp.ten, soluong = quantity });
                    Session["cart"] = lCart;
                    soluong = 1;
                }
                else
                {
                    List<ShoppingCart> lCart = (List<ShoppingCart>)Session["cart"];
                    var cart = lCart.FirstOrDefault(x => x.idsanpham == idsanpham);
                    if (cart == null)
                    {
                        lCart.Add(new ShoppingCart { idsanpham = idsanpham, donvitinh = sp.JF_DonViTinh.ten, giatien = (decimal)sp.giatien, loaisanpham = sp.JF_LoaiSanPham.ten, tensanpham = sp.ten, soluong = quantity });
                    }
                    else
                    {
                        cart.soluong += quantity;
                    }
                    Session["cart"] = lCart;
                    soluong = lCart.Count();
                }

                return Json(new { status = true, message = "Sản phẩm: " + sp.ten + " đã được thêm vào giỏ hàng", soluong = soluong }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                return Json(new { status = false, message = "Lỗi: " + ex }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult getcart()
        {
            try
            {
                List<ShoppingCart> lCart = new List<ShoppingCart>();
                if (Session["cart"] != null)
                {
                    lCart = (List<ShoppingCart>)Session["cart"];
                    return Json(new { status = true, lCart = lCart }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { status = false, message = "Bạn chưa chọn sản phẩm" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                return Json(new { status = false, message = "Lỗi: " + ex }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult removeproduct(int idsanpham)
        {
            try
            {
                List<ShoppingCart> lCart = new List<ShoppingCart>();
                if (Session["cart"] != null)
                {
                    lCart = (List<ShoppingCart>)Session["cart"];
                    var cart = lCart.FirstOrDefault(x => x.idsanpham == idsanpham);
                    lCart.Remove(cart);
                    Session["cart"] = lCart;
                    return Json(new { status = true, lCart = lCart, soluong = lCart.Count() }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { status = false, message = "Không tồn tại sản phẩm." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                return Json(new { status = false, message = "Lỗi: " + ex }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult updateQuantity(int idsanpham, int quantity)
        {
            try
            {
                List<ShoppingCart> lCart = new List<ShoppingCart>();
                if (Session["cart"] != null)
                {
                    lCart = (List<ShoppingCart>)Session["cart"];
                    var cart = lCart.FirstOrDefault(x => x.idsanpham == idsanpham);
                    cart.soluong = quantity;
                    Session["cart"] = lCart;
                    return Json(new { status = true, lCart = lCart }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { status = false, message = "Không tồn tại sản phẩm." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                return Json(new { status = false, message = "Lỗi: " + ex }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}

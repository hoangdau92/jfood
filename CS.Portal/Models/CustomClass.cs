using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core_MVC.Models
{
    public class ShoppingCart
    {
        public int idsanpham { get; set; }
        public string tensanpham { get; set; }
        public string donvitinh { get; set; }
        public string loaisanpham { get; set; }
        public decimal giatien { get; set; }
        public int soluong { get; set; }
    }

    //public static class GlobalVariables
    //{
    //    // read-write variable
    //    public static string Bar
    //    {
    //        get
    //        {
    //            return HttpContext.Current.Application["Bar"] as string;
    //        }
    //        set
    //        {
    //            HttpContext.Current.Application["Bar"] = value;
    //        }
    //    }
    //}
}
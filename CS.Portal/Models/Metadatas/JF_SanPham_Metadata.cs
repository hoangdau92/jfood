using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core_MVC.Models
{
    [MetadataTypeAttribute(typeof(JF_SanPham_Metadata))]
    public partial class JF_SanPham
    {
        public class JF_SanPham_Metadata
        {

            [Display(Name = "Tên")]
            [Required(ErrorMessage = "Vui lòng nhập tên")]
            public string ten { get; set; }

            [Display(Name = "Hình đại diện")]
            public string hinhdaidien { get; set; }

            //[Display(Name = "Mô tả")]
            //public string mota { get; set; }
            [Display(Name = "Giá trước khuyến mãi")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Chỉ nhập số")]
            public string giatruockm { get; set; }

            [Display(Name = "Giá sau khuyến mãi")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Chỉ nhập số")]
            public string giatien { get; set; }

            [Display(Name = "Sản phẩm hot")]
            public string noibat { get; set; }

            [Display(Name = "Hiển thị trang chủ")]
            public string hientrangchu { get; set; }

            [Display(Name = "Loại sản phẩm")]
            [Required(ErrorMessage = "Chọn loại sản phẩm")]
            public string id_loaisanpham { get; set; }

            [Display(Name = "Đơn vị tính")]
            [Required(ErrorMessage = "Chọn đơn vị tính")]
            public string id_donvitinh { get; set; }

            [Display(Name = "Mô tả")]
            public string mota { get; set; }

        }
    }
}
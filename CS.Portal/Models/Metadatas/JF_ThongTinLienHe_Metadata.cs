using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core_MVC.Models
{
    [MetadataTypeAttribute(typeof(JF_ThongTinLienHe_Metadata))]
    public partial class JF_ThongTinLienHe
    {
        public class JF_ThongTinLienHe_Metadata
        {

            [Display(Name = "Tên")]
            [Required(ErrorMessage = "Vui lòng nhập tên")]
            public string ten { get; set; }

            [Display(Name = "Địa chỉ")]
            public string diachi { get; set; }

            [Display(Name = "Fax")]
            public string fax { get; set; }

            [Display(Name = "Email")]
            public string email { get; set; }

            [Display(Name = "Điện thoại")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Chỉ nhập số")]
            public string dienthoai { get; set; }

            [Display(Name = "Tài khoản ngân hàng")]
            public string taikhoannganhang { get; set; }

            [Display(Name = "Tài khoản bưu điện")]
            public string taikhoanbuudien { get; set; }

            [Display(Name = "Slogan")]
            public string slogan { get; set; }

            [Display(Name = "Tên công ty")]
            public string tencongty { get; set; }

        }
    }
}
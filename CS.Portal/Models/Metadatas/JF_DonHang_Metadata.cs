using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core_MVC.Models
{
    [MetadataTypeAttribute(typeof(JF_DonHang_Metadata))]
    public partial class JF_DonHang
    {
        public class JF_DonHang_Metadata
        {

            [Display(Name = "Mã đơn hàng")]
            public string madonhang { get; set; }

            [Display(Name = "Tên khách hàng")]
            [Required(ErrorMessage = "Vui lòng nhập tên")]
            public string tenkhachhang { get; set; }

            [Display(Name = "Email")]
            [Required(ErrorMessage = "Vui lòng nhập email")]
            [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email chưa đúng")]
            public string email { get; set; }

            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
            public string diachi { get; set; }

            [Display(Name = "Số điện thoại")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Chỉ nhập số")]
            public string sodienthoai { get; set; }

            [Display(Name = "Ngày giao hàng")]
            [Required(ErrorMessage = "Vui lòng nhập ngày giao hàng")]
            public DateTime ngaygiaohang { get; set; }

            [Display(Name = "Thời gian giao hàng")]
            public string thoigiangiaohang { get; set; }

            [Display(Name = "Ghi chú khác")]
            public string ghichukhachhang { get; set; }

            [Display(Name = "Phương thức thanh toán")]
            public string phuongthucthanhtoan { get; set; }

            [Display(Name = "Ghi chú")]
            public string motaxuly { get; set; }

        }
    }
}
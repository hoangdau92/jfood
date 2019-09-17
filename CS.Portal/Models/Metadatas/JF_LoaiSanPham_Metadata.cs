using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core_MVC.Models
{
    [MetadataTypeAttribute(typeof(JF_LoaiSanPham_Metadata))]
    public partial class JF_LoaiSanPham
    {
        public class JF_LoaiSanPham_Metadata
        {

            [Display(Name = "Tên")]
            [Required(ErrorMessage = "Vui lòng nhập tên")]
            public string ten { get; set; }

            [Display(Name = "Mô tả")]
            public string mota { get; set; }

            [Display(Name = "Thứ tự")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Chỉ nhập số")]
            public string thutu { get; set; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core_MVC.Models
{
    [MetadataTypeAttribute(typeof(JF_DonViTinh_Metadata))]
    public partial class JF_DonViTinh
    {
        public class JF_DonViTinh_Metadata
        {

            [Display(Name = "Tên")]
            [Required(ErrorMessage = "Vui lòng nhập tên")]
            public string ten { get; set; }

            [Display(Name = "Mô tả")]
            public string mota { get; set; }
        }
    }
}
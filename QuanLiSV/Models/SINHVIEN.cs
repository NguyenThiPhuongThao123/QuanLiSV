using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiSV.Models
{
    [Table("SINHVIENs")]
    public class SINHVIEN
    {
        [Key]
        public string Masv { get; set; }
        [AllowHtml]
        public string Hoten { get; set; }
        public string Diachi { get; set; }
        public string Malop { get; set; }
    }
}
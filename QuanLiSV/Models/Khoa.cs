using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLiSV.Models
{
    [Table("Khoas")]
    public class Khoa : NganhHoc
    {
        public string TenKhoa { get; set; }
    }
}
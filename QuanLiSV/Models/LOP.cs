using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLiSV.Models
{
    [Table("LOPs")]
    public class LOP
    {
        [Key]
        public string Malop { get; set; }
        public string Tenlop { get; set; }
        public string Manghanh { get; set; }
    }
}
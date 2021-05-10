using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLiSV.Models
{
    public class account
    {
        [Key]
        public string username { get; set; }
        public string Password { get; set; }
    }
}
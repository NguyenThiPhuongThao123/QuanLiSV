using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiSV.Models
{
    public class NganhHoc : LOP
    {
        public string Tennghanh { get; set; }
        public string Makhoa { get; set; }
    }
}
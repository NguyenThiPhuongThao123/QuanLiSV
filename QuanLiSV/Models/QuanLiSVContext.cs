using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLiSV.Models
{
    public partial class QuanLiSVContext : DbContext
    {
        public QuanLiSVContext()
            : base("name=QuanLiSVContext")
        {
        }
        public virtual DbSet<SINHVIEN> SINHVIENs { get; set; }
        public virtual DbSet<LOP> LOPs { get; set; }
        public virtual DbSet<NganhHoc> NganhHocs { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<account> accounts { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
    }
    }
}

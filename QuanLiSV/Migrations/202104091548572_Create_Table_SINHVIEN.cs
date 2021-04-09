namespace QuanLiSV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_SINHVIEN : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SINHVIENs",
                c => new
                    {
                        Masv = c.String(nullable: false, maxLength: 128),
                        Hoten = c.String(),
                        Diachi = c.String(),
                        Malop = c.String(),
                    })
                .PrimaryKey(t => t.Masv);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SINHVIENs");
        }
    }
}

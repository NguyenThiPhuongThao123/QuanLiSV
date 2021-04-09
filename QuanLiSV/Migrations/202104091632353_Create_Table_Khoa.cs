namespace QuanLiSV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Khoa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Khoas",
                c => new
                    {
                        Malop = c.String(nullable: false, maxLength: 128),
                        TenKhoa = c.String(),
                    })
                .PrimaryKey(t => t.Malop)
                .ForeignKey("dbo.LOPs", t => t.Malop)
                .Index(t => t.Malop);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Khoas", "Malop", "dbo.LOPs");
            DropIndex("dbo.Khoas", new[] { "Malop" });
            DropTable("dbo.Khoas");
        }
    }
}

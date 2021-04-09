namespace QuanLiSV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_LOP : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LOPs",
                c => new
                    {
                        Malop = c.String(nullable: false, maxLength: 128),
                        Tenlop = c.String(),
                        Manghanh = c.String(),
                    })
                .PrimaryKey(t => t.Malop);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LOPs");
        }
    }
}

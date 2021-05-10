namespace QuanLiSV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class acountttt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.accounts",
                c => new
                    {
                        username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.username);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.accounts");
        }
    }
}

namespace QuanLiSV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_NganhHoc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LOPs", "Tennghanh", c => c.String());
            AddColumn("dbo.LOPs", "Makhoa", c => c.String());
            AddColumn("dbo.LOPs", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LOPs", "Discriminator");
            DropColumn("dbo.LOPs", "Makhoa");
            DropColumn("dbo.LOPs", "Tennghanh");
        }
    }
}

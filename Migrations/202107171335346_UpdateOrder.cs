namespace SkateBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDay", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "OrderPlaceTime");
            DropColumn("dbo.Orders", "Name");
            DropColumn("dbo.Orders", "Address");
            DropColumn("dbo.Orders", "PhoneNumber");
            DropColumn("dbo.Orders", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Email", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Orders", "PhoneNumber", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Orders", "Address", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Orders", "Name", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Orders", "OrderPlaceTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "OrderDay");
        }
    }
}

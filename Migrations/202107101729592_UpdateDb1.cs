namespace SkateBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDb1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Status", c => c.Boolean(nullable: false));
        }
    }
}

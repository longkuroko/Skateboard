namespace SkateBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Username", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Password", c => c.String());
            AlterColumn("dbo.Customers", "Username", c => c.String());
        }
    }
}

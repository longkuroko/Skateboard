namespace SkateBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemSoLuongTon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "SLton", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "SLton");
        }
    }
}

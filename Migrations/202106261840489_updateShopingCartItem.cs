namespace SkateBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateShopingCartItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "ProductId");
            AddForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            DropColumn("dbo.OrderDetails", "ProductName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "ProductName", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropColumn("dbo.OrderDetails", "ProductId");
        }
    }
}

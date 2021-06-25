namespace SkateBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTableBrand : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.ShopingCartItems", "ShopingCart_ShopingCartId", "dbo.ShopingCarts");
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.ShopingCartItems", new[] { "ShopingCart_ShopingCartId" });
            AddColumn("dbo.ShopingCartItems", "Qty", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.ShopingCartItems", "ShoppingCartId", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Products", "BrandId");
            DropColumn("dbo.ShopingCartItems", "Amount");
            DropColumn("dbo.ShopingCartItems", "ShopingCart_ShopingCartId");
            DropTable("dbo.Brands");
            DropTable("dbo.ShopingCarts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShopingCarts",
                c => new
                    {
                        ShopingCartId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ShopingCartId);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.ShopingCartItems", "ShopingCart_ShopingCartId", c => c.String(maxLength: 128));
            AddColumn("dbo.ShopingCartItems", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "BrandId", c => c.Int(nullable: false));
            AlterColumn("dbo.ShopingCartItems", "ShoppingCartId", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            DropColumn("dbo.ShopingCartItems", "Qty");
            CreateIndex("dbo.ShopingCartItems", "ShopingCart_ShopingCartId");
            CreateIndex("dbo.Products", "BrandId");
            AddForeignKey("dbo.ShopingCartItems", "ShopingCart_ShopingCartId", "dbo.ShopingCarts", "ShopingCartId");
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "ID", cascadeDelete: true);
        }
    }
}

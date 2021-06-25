namespace SkateBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateShopingCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShopingCartItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        ShoppingCartId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopingCartItems", "ProductId", "dbo.Products");
            DropIndex("dbo.ShopingCartItems", new[] { "ProductId" });
            DropTable("dbo.ShopingCartItems");
        }
    }
}

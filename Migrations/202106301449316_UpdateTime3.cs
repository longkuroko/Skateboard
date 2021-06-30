namespace SkateBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTime3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShopingCartItems", "ProductId", "dbo.Products");
            DropIndex("dbo.ShopingCartItems", new[] { "ProductId" });
            DropTable("dbo.ShopingCartItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShopingCartItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        ShoppingCartId = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ShopingCartItems", "ProductId");
            AddForeignKey("dbo.ShopingCartItems", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}

namespace SkateBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTime1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShopingCarts",
                c => new
                    {
                        ShopingCartId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ShopingCartId);
            
            AddColumn("dbo.ShopingCartItems", "ShopingCart_ShopingCartId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ShopingCartItems", "ShopingCart_ShopingCartId");
            AddForeignKey("dbo.ShopingCartItems", "ShopingCart_ShopingCartId", "dbo.ShopingCarts", "ShopingCartId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopingCartItems", "ShopingCart_ShopingCartId", "dbo.ShopingCarts");
            DropIndex("dbo.ShopingCartItems", new[] { "ShopingCart_ShopingCartId" });
            DropColumn("dbo.ShopingCartItems", "ShopingCart_ShopingCartId");
            DropTable("dbo.ShopingCarts");
        }
    }
}

namespace SkateBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetime2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShopingCartItems", "ShopingCart_ShopingCartId", "dbo.ShopingCarts");
            DropIndex("dbo.ShopingCartItems", new[] { "ShopingCart_ShopingCartId" });
            DropColumn("dbo.ShopingCartItems", "ShopingCart_ShopingCartId");
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
            
            AddColumn("dbo.ShopingCartItems", "ShopingCart_ShopingCartId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ShopingCartItems", "ShopingCart_ShopingCartId");
            AddForeignKey("dbo.ShopingCartItems", "ShopingCart_ShopingCartId", "dbo.ShopingCarts", "ShopingCartId");
        }
    }
}

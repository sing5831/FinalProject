namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        rentID = c.Int(nullable: false),
                        menuID = c.Int(nullable: false),
                        qtyOrdered = c.Int(nullable: false),
                        orderDueDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.rentID, t.menuID })
                .ForeignKey("dbo.RestaurantMenus", t => t.menuID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.rentID, cascadeDelete: true)
                .Index(t => t.rentID)
                .Index(t => t.menuID);
            
            CreateTable(
                "dbo.RestaurantMenus",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        item = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        qty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        custID = c.Int(nullable: false),
                        orderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.custID, cascadeDelete: true)
                .Index(t => t.custID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "rentID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "custID", "dbo.Customers");
            DropForeignKey("dbo.OrderDetails", "menuID", "dbo.RestaurantMenus");
            DropIndex("dbo.Orders", new[] { "custID" });
            DropIndex("dbo.OrderDetails", new[] { "menuID" });
            DropIndex("dbo.OrderDetails", new[] { "rentID" });
            DropTable("dbo.Orders");
            DropTable("dbo.RestaurantMenus");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Customers");
        }
    }
}

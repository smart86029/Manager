namespace Manager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Generic.BusinessEntity",
                c => new
                    {
                        BusinessEntityId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.BusinessEntityId);
            
            CreateTable(
                "System.Menu",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Area = c.String(maxLength: 50),
                        Controller = c.String(maxLength: 50),
                        Action = c.String(maxLength: 50),
                        Description = c.String(maxLength: 100),
                        Order = c.Int(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.MenuId)
                .ForeignKey("System.Menu", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "System.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "System.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 32),
                        PasswordHash = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                        BusinessEntityId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("Generic.BusinessEntity", t => t.BusinessEntityId)
                .Index(t => t.BusinessEntityId);
            
            CreateTable(
                "GroupBuying.Store",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        Description = c.String(maxLength: 512),
                        Phone = c.String(maxLength: 32),
                        Address = c.String(maxLength: 128),
                        Remark = c.String(maxLength: 512),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StoreId)
                .ForeignKey("System.User", t => t.CreatedBy, cascadeDelete: true)
                .ForeignKey("System.User", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy);
            
            CreateTable(
                "GroupBuying.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("GroupBuying.Store", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId);
            
            CreateTable(
                "System.RoleMenu",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.MenuId })
                .ForeignKey("System.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("System.Menu", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.MenuId);
            
            CreateTable(
                "System.UserRole",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("System.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("System.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("GroupBuying.Store", "UpdatedBy", "System.User");
            DropForeignKey("GroupBuying.Product", "StoreId", "GroupBuying.Store");
            DropForeignKey("GroupBuying.Store", "CreatedBy", "System.User");
            DropForeignKey("System.UserRole", "RoleId", "System.Role");
            DropForeignKey("System.UserRole", "UserId", "System.User");
            DropForeignKey("System.User", "BusinessEntityId", "Generic.BusinessEntity");
            DropForeignKey("System.RoleMenu", "MenuId", "System.Menu");
            DropForeignKey("System.RoleMenu", "RoleId", "System.Role");
            DropForeignKey("System.Menu", "ParentId", "System.Menu");
            DropIndex("System.UserRole", new[] { "RoleId" });
            DropIndex("System.UserRole", new[] { "UserId" });
            DropIndex("System.RoleMenu", new[] { "MenuId" });
            DropIndex("System.RoleMenu", new[] { "RoleId" });
            DropIndex("GroupBuying.Product", new[] { "StoreId" });
            DropIndex("GroupBuying.Store", new[] { "UpdatedBy" });
            DropIndex("GroupBuying.Store", new[] { "CreatedBy" });
            DropIndex("System.User", new[] { "BusinessEntityId" });
            DropIndex("System.Menu", new[] { "ParentId" });
            DropTable("System.UserRole");
            DropTable("System.RoleMenu");
            DropTable("GroupBuying.Product");
            DropTable("GroupBuying.Store");
            DropTable("System.User");
            DropTable("System.Role");
            DropTable("System.Menu");
            DropTable("Generic.BusinessEntity");
        }
    }
}

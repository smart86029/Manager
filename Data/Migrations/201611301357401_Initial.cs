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
                        IsActivated = c.Boolean(nullable: false),
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
                        IsActivated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "System.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        PasswordHash = c.String(),
                        IsActivated = c.Boolean(nullable: false),
                        BusinessEntityId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("Generic.BusinessEntity", t => t.BusinessEntityId)
                .Index(t => t.BusinessEntityId);
            
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
                "System.RoleUser",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("System.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("System.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("System.RoleUser", "UserId", "System.User");
            DropForeignKey("System.RoleUser", "RoleId", "System.Role");
            DropForeignKey("System.User", "BusinessEntityId", "Generic.BusinessEntity");
            DropForeignKey("System.RoleMenu", "MenuId", "System.Menu");
            DropForeignKey("System.RoleMenu", "RoleId", "System.Role");
            DropForeignKey("System.Menu", "ParentId", "System.Menu");
            DropIndex("System.RoleUser", new[] { "UserId" });
            DropIndex("System.RoleUser", new[] { "RoleId" });
            DropIndex("System.RoleMenu", new[] { "MenuId" });
            DropIndex("System.RoleMenu", new[] { "RoleId" });
            DropIndex("System.User", new[] { "BusinessEntityId" });
            DropIndex("System.Menu", new[] { "ParentId" });
            DropTable("System.RoleUser");
            DropTable("System.RoleMenu");
            DropTable("System.User");
            DropTable("System.Role");
            DropTable("System.Menu");
            DropTable("Generic.BusinessEntity");
        }
    }
}

namespace Manager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStore : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Commerce.Store",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Description = c.String(maxLength: 512),
                        Phone = c.String(maxLength: 20),
                        Address = c.String(maxLength: 128),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("Commerce.Store", "UpdatedBy", "System.User");
            DropForeignKey("Commerce.Store", "CreatedBy", "System.User");
            DropIndex("Commerce.Store", new[] { "UpdatedBy" });
            DropIndex("Commerce.Store", new[] { "CreatedBy" });
            DropTable("Commerce.Store");
        }
    }
}

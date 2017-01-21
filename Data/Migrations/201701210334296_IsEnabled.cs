namespace Manager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsEnabled : DbMigration
    {
        public override void Up()
        {
            AddColumn("System.Menu", "IsEnabled", c => c.Boolean(nullable: false));
            AddColumn("System.Role", "IsEnabled", c => c.Boolean(nullable: false));
            AddColumn("System.User", "IsEnabled", c => c.Boolean(nullable: false));
            DropColumn("System.Menu", "IsActivated");
            DropColumn("System.Role", "IsActivated");
            DropColumn("System.User", "IsActivated");
        }
        
        public override void Down()
        {
            AddColumn("System.User", "IsActivated", c => c.Boolean(nullable: false));
            AddColumn("System.Role", "IsActivated", c => c.Boolean(nullable: false));
            AddColumn("System.Menu", "IsActivated", c => c.Boolean(nullable: false));
            DropColumn("System.User", "IsEnabled");
            DropColumn("System.Role", "IsEnabled");
            DropColumn("System.Menu", "IsEnabled");
        }
    }
}

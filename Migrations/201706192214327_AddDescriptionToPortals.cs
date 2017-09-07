namespace Titan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToPortals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Portals", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Portals", "Description");
        }
    }
}

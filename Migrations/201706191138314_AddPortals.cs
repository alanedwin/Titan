namespace Titan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPortals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Portals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PortalName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contacts", "Portal_Id", c => c.Int());
            CreateIndex("dbo.Contacts", "Portal_Id");
            AddForeignKey("dbo.Contacts", "Portal_Id", "dbo.Portals", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "Portal_Id", "dbo.Portals");
            DropIndex("dbo.Contacts", new[] { "Portal_Id" });
            DropColumn("dbo.Contacts", "Portal_Id");
            DropTable("dbo.Portals");
        }
    }
}

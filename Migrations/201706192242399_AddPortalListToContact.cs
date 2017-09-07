namespace Titan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPortalListToContact : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "Portal_Id", "dbo.Portals");
            DropIndex("dbo.Contacts", new[] { "Portal_Id" });
            CreateTable(
                "dbo.PortalContacts",
                c => new
                    {
                        Portal_Id = c.Int(nullable: false),
                        Contact_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Portal_Id, t.Contact_Id })
                .ForeignKey("dbo.Portals", t => t.Portal_Id, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id, cascadeDelete: true)
                .Index(t => t.Portal_Id)
                .Index(t => t.Contact_Id);
            
            DropColumn("dbo.Contacts", "Portal_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Portal_Id", c => c.Int());
            DropForeignKey("dbo.PortalContacts", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.PortalContacts", "Portal_Id", "dbo.Portals");
            DropIndex("dbo.PortalContacts", new[] { "Contact_Id" });
            DropIndex("dbo.PortalContacts", new[] { "Portal_Id" });
            DropTable("dbo.PortalContacts");
            CreateIndex("dbo.Contacts", "Portal_Id");
            AddForeignKey("dbo.Contacts", "Portal_Id", "dbo.Portals", "Id");
        }
    }
}

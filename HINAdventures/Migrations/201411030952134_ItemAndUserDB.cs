namespace HINAdventures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemAndUserDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Description_Id = c.Int(),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Descriptions", t => t.Description_Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Description_Id)
                .Index(t => t.Room_Id);
            
            AddColumn("dbo.AspNetUsers", "Description_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Description_Id");
            AddForeignKey("dbo.AspNetUsers", "Description_Id", "dbo.Descriptions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Description_Id", "dbo.Descriptions");
            DropForeignKey("dbo.Items", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Items", "Description_Id", "dbo.Descriptions");
            DropForeignKey("dbo.Items", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "Description_Id" });
            DropIndex("dbo.Items", new[] { "Room_Id" });
            DropIndex("dbo.Items", new[] { "Description_Id" });
            DropIndex("dbo.Items", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "Description_Id");
            DropTable("dbo.Items");
        }
    }
}

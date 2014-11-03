namespace HINAdventures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Items", "Description_Id", "dbo.Descriptions");
            DropForeignKey("dbo.Items", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.AspNetUsers", "Description_Id", "dbo.Descriptions");
            DropIndex("dbo.Items", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Items", new[] { "Description_Id" });
            DropIndex("dbo.Items", new[] { "Room_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Description_Id" });
            DropColumn("dbo.AspNetUsers", "Description_Id");
            DropTable("dbo.Items");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.AspNetUsers", "Description_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Description_Id");
            CreateIndex("dbo.Items", "Room_Id");
            CreateIndex("dbo.Items", "Description_Id");
            CreateIndex("dbo.Items", "ApplicationUser_Id");
            AddForeignKey("dbo.AspNetUsers", "Description_Id", "dbo.Descriptions", "Id");
            AddForeignKey("dbo.Items", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Items", "Description_Id", "dbo.Descriptions", "Id");
            AddForeignKey("dbo.Items", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

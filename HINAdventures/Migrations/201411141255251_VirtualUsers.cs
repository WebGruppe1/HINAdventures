namespace HINAdventures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VirtualUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VirtualUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.VirtualUserChatCommands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChatCommand = c.String(),
                        SayRegulary = c.Boolean(nullable: false),
                        VirtualUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VirtualUsers", t => t.VirtualUser_Id)
                .Index(t => t.VirtualUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VirtualUserChatCommands", "VirtualUser_Id", "dbo.VirtualUsers");
            DropForeignKey("dbo.VirtualUsers", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.VirtualUserChatCommands", new[] { "VirtualUser_Id" });
            DropIndex("dbo.VirtualUsers", new[] { "Room_Id" });
            DropTable("dbo.VirtualUserChatCommands");
            DropTable("dbo.VirtualUsers");
        }
    }
}

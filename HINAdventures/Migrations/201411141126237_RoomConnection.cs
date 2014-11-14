namespace HINAdventures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoomConnection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoomConnection",
                c => new
                    {
                        Room_Id = c.Int(nullable: false),
                        Room_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_Id, t.Room_Id1 })
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id1)
                .Index(t => t.Room_Id)
                .Index(t => t.Room_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomConnection", "Room_Id1", "dbo.Rooms");
            DropForeignKey("dbo.RoomConnection", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.RoomConnection", new[] { "Room_Id1" });
            DropIndex("dbo.RoomConnection", new[] { "Room_Id" });
            DropTable("dbo.RoomConnection");
        }
    }
}

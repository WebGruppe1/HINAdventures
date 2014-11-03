namespace HINAdventures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRoomModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description_Id = c.Int(nullable: true),
                        East_Id = c.Int(nullable: true),
                        North_Id = c.Int(nullable: true),
                        South_Id = c.Int(nullable: true),
                        West_Id = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Descriptions", t => t.Description_Id)
                .ForeignKey("dbo.Rooms", t => t.East_Id)
                .ForeignKey("dbo.Rooms", t => t.North_Id)
                .ForeignKey("dbo.Rooms", t => t.South_Id)
                .ForeignKey("dbo.Rooms", t => t.West_Id)
                .Index(t => t.Description_Id)
                .Index(t => t.East_Id)
                .Index(t => t.North_Id)
                .Index(t => t.South_Id)
                .Index(t => t.West_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "West_Id", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "South_Id", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "North_Id", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "East_Id", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "Description_Id", "dbo.Descriptions");
            DropIndex("dbo.Rooms", new[] { "West_Id" });
            DropIndex("dbo.Rooms", new[] { "South_Id" });
            DropIndex("dbo.Rooms", new[] { "North_Id" });
            DropIndex("dbo.Rooms", new[] { "East_Id" });
            DropIndex("dbo.Rooms", new[] { "Description_Id" });
            DropTable("dbo.Rooms");
        }
    }
}

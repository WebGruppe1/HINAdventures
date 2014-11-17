namespace HINAdventures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserHasRoomAndItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Room_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Room_Id");
            AddForeignKey("dbo.AspNetUsers", "Room_Id", "dbo.Rooms", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.AspNetUsers", new[] { "Room_Id" });
            DropColumn("dbo.AspNetUsers", "Room_Id");
        }
    }
}

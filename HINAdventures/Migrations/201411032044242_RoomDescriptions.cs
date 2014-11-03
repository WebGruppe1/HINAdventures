namespace HINAdventures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoomDescriptions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "Description_Id", "dbo.Descriptions");
            DropIndex("dbo.Rooms", new[] { "Description_Id" });
            AddColumn("dbo.Rooms", "OutsideDescription", c => c.String());
            AddColumn("dbo.Rooms", "Description", c => c.String());
            DropColumn("dbo.Rooms", "Description_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Description_Id", c => c.Int());
            DropColumn("dbo.Rooms", "Description");
            DropColumn("dbo.Rooms", "OutsideDescription");
            CreateIndex("dbo.Rooms", "Description_Id");
            AddForeignKey("dbo.Rooms", "Description_Id", "dbo.Descriptions", "Id");
        }
    }
}

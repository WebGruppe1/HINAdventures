namespace HINAdventures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ukjent2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WhiteBoards", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.WhiteBoards", new[] { "ApplicationUser_Id" });
            DropTable("dbo.WhiteBoards");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WhiteBoards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.WhiteBoards", "ApplicationUser_Id");
            AddForeignKey("dbo.WhiteBoards", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

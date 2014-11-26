namespace HINAdventures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeAuthorWhiteBoard : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WhiteBoardBlogs", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.WhiteBoardBlogs", new[] { "Author_Id" });
            DropColumn("dbo.WhiteBoardBlogs", "Author_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WhiteBoardBlogs", "Author_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.WhiteBoardBlogs", "Author_Id");
            AddForeignKey("dbo.WhiteBoardBlogs", "Author_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

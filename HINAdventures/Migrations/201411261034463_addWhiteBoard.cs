namespace HINAdventures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addWhiteBoard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WhiteBoardBlogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.WhiteBoardComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Created = c.DateTime(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                        Blog_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .ForeignKey("dbo.WhiteBoardBlogs", t => t.Blog_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Blog_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WhiteBoardBlogs", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.WhiteBoardComments", "Blog_Id", "dbo.WhiteBoardBlogs");
            DropForeignKey("dbo.WhiteBoardComments", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WhiteBoardBlogs", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.WhiteBoardComments", new[] { "Blog_Id" });
            DropIndex("dbo.WhiteBoardComments", new[] { "Author_Id" });
            DropIndex("dbo.WhiteBoardBlogs", new[] { "Room_Id" });
            DropIndex("dbo.WhiteBoardBlogs", new[] { "Author_Id" });
            DropTable("dbo.WhiteBoardComments");
            DropTable("dbo.WhiteBoardBlogs");
        }
    }
}

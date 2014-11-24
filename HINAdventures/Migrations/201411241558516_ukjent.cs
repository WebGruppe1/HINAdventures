namespace HINAdventures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ukjent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WhiteBoardBlogs", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WhiteBoardBlogs", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.WhiteBordComments", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WhiteBordComments", "Blog_Id", "dbo.WhiteBoardBlogs");
            DropIndex("dbo.WhiteBoardBlogs", new[] { "Author_Id" });
            DropIndex("dbo.WhiteBoardBlogs", new[] { "Room_Id" });
            DropIndex("dbo.WhiteBordComments", new[] { "Author_Id" });
            DropIndex("dbo.WhiteBordComments", new[] { "Blog_Id" });
            DropTable("dbo.WhiteBoardBlogs");
            DropTable("dbo.WhiteBordComments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WhiteBordComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Created = c.DateTime(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                        Blog_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.WhiteBordComments", "Blog_Id");
            CreateIndex("dbo.WhiteBordComments", "Author_Id");
            CreateIndex("dbo.WhiteBoardBlogs", "Room_Id");
            CreateIndex("dbo.WhiteBoardBlogs", "Author_Id");
            AddForeignKey("dbo.WhiteBordComments", "Blog_Id", "dbo.WhiteBoardBlogs", "Id");
            AddForeignKey("dbo.WhiteBordComments", "Author_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.WhiteBoardBlogs", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.WhiteBoardBlogs", "Author_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

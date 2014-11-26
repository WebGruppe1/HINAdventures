namespace HINAdventures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remoteWhiteBoardcomments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WhiteBoardComments", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WhiteBoardComments", "Blog_Id", "dbo.WhiteBoardBlogs");
            DropIndex("dbo.WhiteBoardComments", new[] { "Author_Id" });
            DropIndex("dbo.WhiteBoardComments", new[] { "Blog_Id" });
            DropColumn("dbo.WhiteBoardBlogs", "Title");
            DropTable("dbo.WhiteBoardComments");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.WhiteBoardBlogs", "Title", c => c.String());
            CreateIndex("dbo.WhiteBoardComments", "Blog_Id");
            CreateIndex("dbo.WhiteBoardComments", "Author_Id");
            AddForeignKey("dbo.WhiteBoardComments", "Blog_Id", "dbo.WhiteBoardBlogs", "Id");
            AddForeignKey("dbo.WhiteBoardComments", "Author_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

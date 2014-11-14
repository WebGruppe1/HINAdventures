namespace HINAdventures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameAddedToDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Descriptions", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Descriptions", "Name");
        }
    }
}

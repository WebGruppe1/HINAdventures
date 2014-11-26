namespace HINAdventures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeSayRegularVirtualUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.VirtualUserChatCommands", "SayRegulary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VirtualUserChatCommands", "SayRegulary", c => c.Boolean(nullable: false));
        }
    }
}

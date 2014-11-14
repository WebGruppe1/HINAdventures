namespace HINAdventures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrinkAndEatToItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "isEatable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Items", "isDrinkable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "isDrinkable");
            DropColumn("dbo.Items", "isEatable");
        }
    }
}

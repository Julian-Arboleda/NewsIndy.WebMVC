namespace NewsIndy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class replacedplaceboolswithDescriptionproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organization", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Organization", "IsFoodBank");
            DropColumn("dbo.Organization", "IsShelter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Organization", "IsShelter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Organization", "IsFoodBank", c => c.Boolean(nullable: false));
            DropColumn("dbo.Organization", "Description");
        }
    }
}

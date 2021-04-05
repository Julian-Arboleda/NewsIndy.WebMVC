namespace NewsIndy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedvolunteertable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Volunteer", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Volunteer", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Volunteer", "LastName", c => c.String());
            AlterColumn("dbo.Volunteer", "FirstName", c => c.String());
        }
    }
}

namespace NewsIndy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmessagefunctionality : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        CreatorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Message");
        }
    }
}

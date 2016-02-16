namespace bizcard.online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrequiredfieldvalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AssignedCards", "ToEmail", c => c.String(nullable: false));
            AlterColumn("dbo.AssignedCards", "FromEmail", c => c.String(nullable: false));
            AlterColumn("dbo.AssignedCards", "Message", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AssignedCards", "Message", c => c.String());
            AlterColumn("dbo.AssignedCards", "FromEmail", c => c.String());
            AlterColumn("dbo.AssignedCards", "ToEmail", c => c.String());
        }
    }
}

namespace bizcard.online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removedminrequirementformessage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AssignedCards", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AssignedCards", "Message", c => c.String(nullable: false, maxLength: 30));
        }
    }
}

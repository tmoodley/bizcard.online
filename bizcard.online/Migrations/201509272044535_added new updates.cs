namespace bizcard.online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednewupdates : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Newsletter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Newsletter", c => c.Boolean(nullable: false));
        }
    }
}

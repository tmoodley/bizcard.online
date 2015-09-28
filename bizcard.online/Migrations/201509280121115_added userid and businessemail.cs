namespace bizcard.online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduseridandbusinessemail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserId", c => c.String());
            AddColumn("dbo.AspNetUsers", "BusinessEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BusinessEmail");
            DropColumn("dbo.AspNetUsers", "UserId");
        }
    }
}

namespace bizcard.online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedContactModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DirectNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "FaxNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "BusinessNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "Title", c => c.String());
            DropColumn("dbo.AspNetUsers", "HomePhone");
            DropColumn("dbo.AspNetUsers", "CellPhone");
            DropColumn("dbo.AspNetUsers", "BusinessPhone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "BusinessPhone", c => c.String());
            AddColumn("dbo.AspNetUsers", "CellPhone", c => c.String());
            AddColumn("dbo.AspNetUsers", "HomePhone", c => c.String());
            DropColumn("dbo.AspNetUsers", "Title");
            DropColumn("dbo.AspNetUsers", "BusinessNumber");
            DropColumn("dbo.AspNetUsers", "FaxNumber");
            DropColumn("dbo.AspNetUsers", "DirectNumber");
        }
    }
}

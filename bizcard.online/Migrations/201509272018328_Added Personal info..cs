namespace bizcard.online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPersonalinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Bio", c => c.String());
            AddColumn("dbo.AspNetUsers", "PersonalLink", c => c.String());
            AddColumn("dbo.AspNetUsers", "ImageName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address1", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address2", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
            AddColumn("dbo.AspNetUsers", "PostalCode", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "HomePhone", c => c.String());
            AddColumn("dbo.AspNetUsers", "CellPhone", c => c.String());
            AddColumn("dbo.AspNetUsers", "BusinessPhone", c => c.String());
            AddColumn("dbo.AspNetUsers", "Newsletter", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Website", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Website");
            DropColumn("dbo.AspNetUsers", "Newsletter");
            DropColumn("dbo.AspNetUsers", "BusinessPhone");
            DropColumn("dbo.AspNetUsers", "CellPhone");
            DropColumn("dbo.AspNetUsers", "HomePhone");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "PostalCode");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Address2");
            DropColumn("dbo.AspNetUsers", "Address1");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "ImageName");
            DropColumn("dbo.AspNetUsers", "PersonalLink");
            DropColumn("dbo.AspNetUsers", "Bio");
        }
    }
}

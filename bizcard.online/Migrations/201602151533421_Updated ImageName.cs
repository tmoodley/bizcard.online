namespace bizcard.online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedImageName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "ImageName", c => c.String());
            DropColumn("dbo.Cards", "Url");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cards", "Url", c => c.String());
            DropColumn("dbo.Cards", "ImageName");
        }
    }
}

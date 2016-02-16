namespace bizcard.online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlinktocards : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignedCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToEmail = c.String(),
                        FromEmail = c.String(),
                        Message = c.String(),
                        CardId = c.Int(nullable: false),
                        Cards_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Cards_Id)
                .Index(t => t.Cards_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignedCards", "Cards_Id", "dbo.Cards");
            DropIndex("dbo.AssignedCards", new[] { "Cards_Id" });
            DropTable("dbo.AssignedCards");
        }
    }
}

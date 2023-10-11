namespace MyLearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_footers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Footers",
                c => new
                    {
                        FooterID = c.Int(nullable: false, identity: true),
                        FooterLinks = c.String(),
                    })
                .PrimaryKey(t => t.FooterID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Footers");
        }
    }
}

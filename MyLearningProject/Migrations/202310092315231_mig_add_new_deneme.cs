namespace MyLearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_new_deneme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DenemeAdmins",
                c => new
                    {
                        DenemeAdminID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Pass = c.String(),
                    })
                .PrimaryKey(t => t.DenemeAdminID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DenemeAdmins");
        }
    }
}

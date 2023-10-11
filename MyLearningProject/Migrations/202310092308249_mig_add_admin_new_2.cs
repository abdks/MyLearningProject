namespace MyLearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_add_admin_new_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DenemeAdmins",
                c => new
                {
                    AdminID = c.Int(nullable: false, identity: true),
                    Email = c.String(),
                    Pass = c.String(),
                })
                .PrimaryKey(t => t.AdminID);
        }

        public override void Down()
        {
            DropTable("dbo.DenemeAdmins");
        }
    }
}

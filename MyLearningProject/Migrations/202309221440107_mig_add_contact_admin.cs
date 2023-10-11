namespace MyLearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_contact_admin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactAdmins",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        ContactTitle = c.Int(nullable: false),
                        ContactDescription = c.Int(nullable: false),
                        ContactAdress = c.Int(nullable: false),
                        ContactPhone = c.Int(nullable: false),
                        ContactMail = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactAdmins");
        }
    }
}

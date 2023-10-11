namespace MyLearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_contact_admin_v2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactAdmins", "ContactTitle", c => c.String());
            AlterColumn("dbo.ContactAdmins", "ContactDescription", c => c.String());
            AlterColumn("dbo.ContactAdmins", "ContactAdress", c => c.String());
            AlterColumn("dbo.ContactAdmins", "ContactPhone", c => c.String());
            AlterColumn("dbo.ContactAdmins", "ContactMail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactAdmins", "ContactMail", c => c.Int(nullable: false));
            AlterColumn("dbo.ContactAdmins", "ContactPhone", c => c.Int(nullable: false));
            AlterColumn("dbo.ContactAdmins", "ContactAdress", c => c.Int(nullable: false));
            AlterColumn("dbo.ContactAdmins", "ContactDescription", c => c.Int(nullable: false));
            AlterColumn("dbo.ContactAdmins", "ContactTitle", c => c.Int(nullable: false));
        }
    }
}

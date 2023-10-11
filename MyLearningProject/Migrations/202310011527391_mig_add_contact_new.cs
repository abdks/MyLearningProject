namespace MyLearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_contact_new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactAdmins", "ContactTwitter", c => c.String());
            AddColumn("dbo.ContactAdmins", "ContactFacebook", c => c.String());
            AddColumn("dbo.ContactAdmins", "ContactYoutube", c => c.String());
            AddColumn("dbo.ContactAdmins", "ContactLinkedin", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactAdmins", "ContactLinkedin");
            DropColumn("dbo.ContactAdmins", "ContactYoutube");
            DropColumn("dbo.ContactAdmins", "ContactFacebook");
            DropColumn("dbo.ContactAdmins", "ContactTwitter");
        }
    }
}

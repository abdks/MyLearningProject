namespace MyLearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_Instructor_titleAnd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instructors", "Title", c => c.String());
            AddColumn("dbo.Instructors", "ProfileImage", c => c.String());
            AddColumn("dbo.Instructors", "CoverImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instructors", "CoverImage");
            DropColumn("dbo.Instructors", "ProfileImage");
            DropColumn("dbo.Instructors", "Title");
        }
    }
}

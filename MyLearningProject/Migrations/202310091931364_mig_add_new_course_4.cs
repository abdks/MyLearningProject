namespace MyLearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_new_course_4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Video", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Video");
        }
    }
}

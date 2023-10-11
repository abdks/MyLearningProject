namespace MyLearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_student_new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Img", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Img");
        }
    }
}

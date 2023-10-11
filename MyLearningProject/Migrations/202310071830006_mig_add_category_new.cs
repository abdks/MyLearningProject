namespace MyLearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_category_new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryFilter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryFilter");
        }
    }
}

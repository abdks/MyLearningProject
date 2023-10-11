namespace MyLearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_new_comment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Value");
        }
    }
}

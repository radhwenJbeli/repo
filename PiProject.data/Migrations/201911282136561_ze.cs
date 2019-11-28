namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ze : DbMigration
    {
        public override void Up()
        {
            AddColumn("t_performancenote", "NbreBadFeedbacks", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("pi.t_performancenote", "NbreBadFeedbacks");
        }
    }
}

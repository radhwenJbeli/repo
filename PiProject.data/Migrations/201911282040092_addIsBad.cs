namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsBad : DbMigration
    {
        public override void Up()
        {
            AddColumn("t_feedback", "isBad", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("pi.t_feedback", "isBad");
        }
    }
}

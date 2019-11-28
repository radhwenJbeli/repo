namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class er : DbMigration
    {
        public override void Up()
        {
            DropColumn("t_performancenote", "globalNote");
        }
        
        public override void Down()
        {
            AddColumn("pi.t_performancenote", "globalNote", c => c.Single(nullable: false));
        }
    }
}

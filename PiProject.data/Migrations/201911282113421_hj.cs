namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hj : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            AddColumn("pi.t_performancenote", "globalNote", c => c.Single(nullable: false));
        }
    }
}

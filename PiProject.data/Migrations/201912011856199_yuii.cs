namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yuii : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.t_Warning", "gravity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.t_Warning", "gravity");
        }
    }
}

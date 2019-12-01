namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gjlf : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.t_Warning", "warningGravity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.t_Warning", "warningGravity", c => c.Int(nullable: false));
        }
    }
}

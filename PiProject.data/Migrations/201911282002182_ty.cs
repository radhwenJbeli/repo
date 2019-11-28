namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.t_Warning", "is_Confirmed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.t_Warning", "is_Confirmed");
        }
    }
}

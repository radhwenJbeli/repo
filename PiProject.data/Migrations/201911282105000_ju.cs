namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ju : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.t_Warning", "is_Confirmed", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.t_Warning", "is_Confirmed", c => c.Boolean(nullable: false));
        }
    }
}

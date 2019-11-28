namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
			DropTable("pi.t_notification");
		}
        
        public override void Down()
        {
            MoveTable(name: "pi.t_notification", newSchema: "dbo");
        }
    }
}

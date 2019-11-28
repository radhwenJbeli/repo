namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mm : DbMigration
    {
        public override void Up()
        {
			DropForeignKey("pi.t_notification", "WarningId", "t_Warning");
			DropIndex("pi.t_notification", new[] { "WarningId" });
			DropColumn("pi.t_notification", "WarningId");
			

			
        }
        
        public override void Down()
        {
			MoveTable(name: "pi.t_notification", newSchema: "dbo");
			AddColumn("pi.t_notification", "WarningId", c => c.Int());
			CreateIndex("pi.t_notification", "WarningId");
			AddForeignKey("pi.t_notification", "WarningId", "t_Warning", "WId");
		}
    }
}

namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("pi.t_notification", "NotifId", "t_warning");
            DropIndex("pi.t_notification", new[] { "NotifId" });
            DropColumn("pi.t_notification", "NotifId");
        }
        
        public override void Down()
        {
            AddColumn("pi.t_notification", "NotifId", c => c.Int());
            CreateIndex("pi.t_notification", "NotifId");
            AddForeignKey("pi.t_notification", "NotifId", "t_warning", "WId");
        }
    }
}

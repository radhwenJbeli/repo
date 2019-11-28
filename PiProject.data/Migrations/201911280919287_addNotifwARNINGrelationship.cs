namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNotifwARNINGrelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("pi.t_notification", "NotifId", c => c.Int());
            CreateIndex("pi.t_notification", "NotifId");
            AddForeignKey("pi.t_notification", "NotifId", "dbo.t_warning", "WId");
        }
        
        public override void Down()
        {
            DropForeignKey("pi.t_notification", "NotifId", "dbo.t_warning");
            DropIndex("pi.t_notification", new[] { "NotifId" });
            DropColumn("pi.t_notification", "NotifId");
        }
    }
}

namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_notifTarget : DbMigration
    {
        public override void Up()
        {
            AddColumn("pi.t_notification", "targetId", c => c.Int(nullable: false));
            CreateIndex("pi.t_notification", "targetId");
            AddForeignKey("pi.t_notification", "targetId", "t_collaborator", "C_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("pi.t_notification", "targetId", "t_collaborator");
            DropIndex("pi.t_notification", new[] { "targetId" });
            DropColumn("pi.t_notification", "targetId");
        }
    }
}

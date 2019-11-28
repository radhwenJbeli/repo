namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nn : DbMigration
    {
        public override void Up()
        {
           
            CreateTable(
                "dbo.t_Notif",
                c => new
                    {
                        IDNotif = c.Int(nullable: false, identity: true),
                        content = c.String(maxLength: 255, unicode: false, storeType: "nvarchar"),
                        is_checked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IDNotif);
            
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.t_Notification", "WarningId", c => c.Int());
            AddColumn("dbo.t_Notification", "targetId", c => c.Int(nullable: false));
            DropForeignKey("dbo.t_Notification", "t_collaborator_C_ID", "pi.t_collaborator");
            DropIndex("dbo.t_Notification", new[] { "t_collaborator_C_ID" });
            DropColumn("dbo.t_Notification", "t_collaborator_C_ID");
            DropTable("dbo.t_Notif");
            CreateIndex("pi.t_notification", "targetId");
            CreateIndex("pi.t_notification", "WarningId");
            AddForeignKey("pi.t_notification", "targetId", "pi.t_collaborator", "C_ID", cascadeDelete: true);
            AddForeignKey("pi.t_notification", "WarningId", "dbo.t_Warning", "WId");
            MoveTable(name: "dbo.t_Notification", newSchema: "pi");
        }
    }
}

namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nbvc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.t_Notif", "collabId", c => c.Int(nullable: false));
           
            CreateIndex("dbo.t_Notif", "collabId");
            
            AddForeignKey("dbo.t_Notif", "collabId", "t_collaborator", "C_ID", cascadeDelete: true);
           
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_Notif", "WarningId", "dbo.t_Warning");
            DropForeignKey("dbo.t_Notif", "collabId", "pi.t_collaborator");
            DropIndex("dbo.t_Notif", new[] { "WarningId" });
            DropIndex("dbo.t_Notif", new[] { "collabId" });
            DropColumn("dbo.t_Notif", "WarningId");
            DropColumn("dbo.t_Notif", "collabId");
        }
    }
}

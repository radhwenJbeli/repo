namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kl : DbMigration
    {
        public override void Up()
        {
           
            
            
            AddColumn("t_performancenote", "idRank", c => c.Int());
            CreateIndex("t_performancenote", "idRank");
           
            AddForeignKey("t_performancenote", "idRank", "dbo.t_ranking", "idRanking");
           
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.t_Notification",
                c => new
                    {
                        IDNotif = c.Int(nullable: false, identity: true),
                        content = c.String(maxLength: 255, unicode: false, storeType: "nvarchar"),
                        is_checked = c.Boolean(nullable: false),
                        t_collaborator_C_ID = c.Int(),
                    })
                .PrimaryKey(t => t.IDNotif);
            
            DropForeignKey("dbo.t_Notif", "collabId", "pi.t_collaborator");
            DropForeignKey("pi.t_performancenote", "idRank", "dbo.t_ranking");
            DropIndex("dbo.t_Notif", new[] { "collabId" });
            DropIndex("pi.t_performancenote", new[] { "idRank" });
            DropColumn("pi.t_performancenote", "idRank");
            DropColumn("pi.t_performancenote", "globalNote");
            DropTable("dbo.t_ranking");
            CreateIndex("dbo.t_Notification", "t_collaborator_C_ID");
            AddForeignKey("dbo.t_Notification", "t_collaborator_C_ID", "pi.t_collaborator", "C_ID");
        }
    }
}

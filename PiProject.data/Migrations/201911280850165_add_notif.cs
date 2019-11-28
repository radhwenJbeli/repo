namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_notif : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "pi.t_notification",
                c => new
                    {
                        IDNotif = c.Int(nullable: false, identity: true),
                        content = c.String(unicode: false),
                        is_checked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IDNotif);
            
        }
        
        public override void Down()
        {
            DropTable("pi.t_notification");
        }
    }
}

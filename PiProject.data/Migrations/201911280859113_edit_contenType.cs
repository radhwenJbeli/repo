namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_contenType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("pi.t_notification", "content", c => c.String(maxLength: 255, unicode: false, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("pi.t_notification", "content", c => c.String(unicode: false));
        }
    }
}

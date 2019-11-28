namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class l : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.t_Warning",
                c => new
                    {
                        WId = c.Int(nullable: false, identity: true),
                        Reason = c.String(maxLength: 255, unicode: false, storeType: "nvarchar"),
                        Content = c.String(maxLength: 255, unicode: false, storeType: "nvarchar"),
                        warningGravity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.t_Warning");
        }
    }
}

namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "pi.__migrationhistory",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 150, unicode: false),
                        ContextKey = c.String(nullable: false, maxLength: 300, unicode: false),
                        Model = c.Binary(nullable: false),
                        ProductVersion = c.String(nullable: false, maxLength: 32, unicode: false),
                    })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
            
        }
        
        public override void Down()
        {
           
           
        
            DropTable("pi.__migrationhistory");
        }
    }
}

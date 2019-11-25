namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_test_Table : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Table1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Table1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}

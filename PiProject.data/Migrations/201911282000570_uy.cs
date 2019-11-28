namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.t_Warning", "ManagerId", c => c.Int());
            CreateIndex("dbo.t_Warning", "ManagerId");
            AddForeignKey("dbo.t_Warning", "ManagerId", "t_manager", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_Warning", "ManagerId", "pi.t_manager");
            DropIndex("dbo.t_Warning", new[] { "ManagerId" });
            DropColumn("dbo.t_Warning", "ManagerId");
        }
    }
}

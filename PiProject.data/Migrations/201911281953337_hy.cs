namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.t_Warning", "ToWarnId", c => c.Int());
            CreateIndex("dbo.t_Warning", "ToWarnId");
            AddForeignKey("dbo.t_Warning", "ToWarnId", "t_collaborator", "C_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_Warning", "ToWarnId", "pi.t_collaborator");
            DropIndex("dbo.t_Warning", new[] { "ToWarnId" });
            DropColumn("dbo.t_Warning", "ToWarnId");
        }
    }
}

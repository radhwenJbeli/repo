namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cxvb : DbMigration
    {
        public override void Up()
        {
            AddColumn("t_answertestaffectation", "isAnsw", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("pi.t_answertestaffectation", "isAnsw");
        }
    }
}

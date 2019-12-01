namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bnc : DbMigration
    {
        public override void Up()
        {
            DropColumn("t_evaluationguestaffectation", "isAnsw");
        }
        
        public override void Down()
        {
            AddColumn("pi.t_evaluationguestaffectation", "isAnsw", c => c.Int());
        }
    }
}

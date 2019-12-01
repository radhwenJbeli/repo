namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghgj : DbMigration
    {
        public override void Up()
        {
            AddColumn("t_evaluationguestaffectation", "isAnsw", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("pi.t_evaluationguestaffectation", "isAnsw");
        }
    }
}

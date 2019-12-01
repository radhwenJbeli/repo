namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghj : DbMigration
    {
        public override void Up()
        {
            DropColumn("t_answertestaffectation", "isAnsw");
        }
        
        public override void Down()
        {
            AddColumn("pi.t_answertestaffectation", "isAnsw", c => c.Int());
        }
    }
}

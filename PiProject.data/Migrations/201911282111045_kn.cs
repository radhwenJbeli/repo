namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kn : DbMigration
    {
        public override void Up()
        {
			DropColumn("t_performancenote", "globalNote");
		}
        
        public override void Down()
        {
            DropColumn("pi.t_performancenote", "globalNote");
        }
    }
}

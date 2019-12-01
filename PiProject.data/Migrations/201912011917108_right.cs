namespace PiProject.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class right : DbMigration
    {
        public override void Up()
        {
            AddColumn("t_possibleresponse", "isRight", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("pi.t_possibleresponse", "isRight");
        }
    }
}

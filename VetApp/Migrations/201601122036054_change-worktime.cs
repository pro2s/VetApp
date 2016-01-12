namespace VetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeworktime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VetWorkTimes", "Day", c => c.Int(nullable: false));
            DropColumn("dbo.WorkTimes", "Day");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkTimes", "Day", c => c.Int(nullable: false));
            DropColumn("dbo.VetWorkTimes", "Day");
        }
    }
}

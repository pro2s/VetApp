namespace VetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkvetworktime : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VetWorkTimes", "WorkTime_ID", "dbo.WorkTimes");
            DropIndex("dbo.VetWorkTimes", new[] { "WorkTime_ID" });
            RenameColumn(table: "dbo.VetWorkTimes", name: "WorkTime_ID", newName: "WorkTimeId");
            AlterColumn("dbo.VetWorkTimes", "WorkTimeId", c => c.Int(nullable: false));
            CreateIndex("dbo.VetWorkTimes", "WorkTimeId");
            AddForeignKey("dbo.VetWorkTimes", "WorkTimeId", "dbo.WorkTimes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VetWorkTimes", "WorkTimeId", "dbo.WorkTimes");
            DropIndex("dbo.VetWorkTimes", new[] { "WorkTimeId" });
            AlterColumn("dbo.VetWorkTimes", "WorkTimeId", c => c.Int());
            RenameColumn(table: "dbo.VetWorkTimes", name: "WorkTimeId", newName: "WorkTime_ID");
            CreateIndex("dbo.VetWorkTimes", "WorkTime_ID");
            AddForeignKey("dbo.VetWorkTimes", "WorkTime_ID", "dbo.WorkTimes", "ID");
        }
    }
}

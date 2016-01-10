namespace VetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vetworktime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VetWorkTimes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Vet_ID = c.Int(),
                        WorkTime_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Vets", t => t.Vet_ID)
                .ForeignKey("dbo.WorkTimes", t => t.WorkTime_ID)
                .Index(t => t.Vet_ID)
                .Index(t => t.WorkTime_ID);
            
            CreateTable(
                "dbo.WorkTimes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Day = c.Int(nullable: false),
                        start = c.Int(nullable: false),
                        end = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VetWorkTimes", "WorkTime_ID", "dbo.WorkTimes");
            DropForeignKey("dbo.VetWorkTimes", "Vet_ID", "dbo.Vets");
            DropIndex("dbo.VetWorkTimes", new[] { "WorkTime_ID" });
            DropIndex("dbo.VetWorkTimes", new[] { "Vet_ID" });
            DropTable("dbo.WorkTimes");
            DropTable("dbo.VetWorkTimes");
        }
    }
}

namespace VetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vetworktimevet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VetWorkTimes", "Vet_ID", "dbo.Vets");
            DropIndex("dbo.VetWorkTimes", new[] { "Vet_ID" });
            RenameColumn(table: "dbo.VetWorkTimes", name: "Vet_ID", newName: "VetId");
            AlterColumn("dbo.VetWorkTimes", "VetId", c => c.Int(nullable: false));
            CreateIndex("dbo.VetWorkTimes", "VetId");
            AddForeignKey("dbo.VetWorkTimes", "VetId", "dbo.Vets", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VetWorkTimes", "VetId", "dbo.Vets");
            DropIndex("dbo.VetWorkTimes", new[] { "VetId" });
            AlterColumn("dbo.VetWorkTimes", "VetId", c => c.Int());
            RenameColumn(table: "dbo.VetWorkTimes", name: "VetId", newName: "Vet_ID");
            CreateIndex("dbo.VetWorkTimes", "Vet_ID");
            AddForeignKey("dbo.VetWorkTimes", "Vet_ID", "dbo.Vets", "ID");
        }
    }
}

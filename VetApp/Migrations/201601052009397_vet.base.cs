namespace VetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vetbase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimalTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Examinations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PetId = c.Int(nullable: false),
                        Temperature = c.Single(),
                        Pulse = c.Single(),
                        Weight = c.Single(),
                        Lenght = c.Single(),
                        Hieght = c.Single(),
                        CoverState = c.String(),
                        AtClinic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .Index(t => t.PetId);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NickName = c.String(nullable: false),
                        ChipID = c.String(),
                        BornDate = c.DateTime(nullable: false),
                        Sex = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                        PetTypeId = c.Int(nullable: false),
                        CoverColor = c.String(),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.PetTypes", t => t.PetTypeId, cascadeDelete: true)
                .Index(t => t.PetTypeId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.PetTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        AnimalTypeId = c.Int(nullable: false),
                        CoverId = c.Int(),
                        BreedId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AnimalTypes", t => t.AnimalTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Breeds", t => t.BreedId)
                .ForeignKey("dbo.Covers", t => t.CoverId)
                .Index(t => t.AnimalTypeId)
                .Index(t => t.CoverId)
                .Index(t => t.BreedId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        Profile = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .Index(t => t.PetId);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VisitDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        VisitTypeId = c.Int(nullable: false),
                        PetId = c.Int(nullable: false),
                        VetId = c.Int(nullable: false),
                        ExaminationId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Examinations", t => t.ExaminationId)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .ForeignKey("dbo.Vets", t => t.VetId, cascadeDelete: true)
                .ForeignKey("dbo.VisitTypes", t => t.VisitTypeId, cascadeDelete: true)
                .Index(t => t.VisitTypeId)
                .Index(t => t.PetId)
                .Index(t => t.VetId)
                .Index(t => t.ExaminationId);
            
            CreateTable(
                "dbo.Vets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        PersonId = c.Int(),
                        VetTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.PersonId)
                .ForeignKey("dbo.VetTypes", t => t.VetTypeId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.VetTypeId);
            
            CreateTable(
                "dbo.VetTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsDoctor = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VisitTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        SelfRegistration = c.Boolean(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Examinations", "PetId", "dbo.Pets");
            DropForeignKey("dbo.Visits", "VisitTypeId", "dbo.VisitTypes");
            DropForeignKey("dbo.Visits", "VetId", "dbo.Vets");
            DropForeignKey("dbo.Vets", "VetTypeId", "dbo.VetTypes");
            DropForeignKey("dbo.Vets", "PersonId", "dbo.People");
            DropForeignKey("dbo.Visits", "PetId", "dbo.Pets");
            DropForeignKey("dbo.Visits", "ExaminationId", "dbo.Examinations");
            DropForeignKey("dbo.Photos", "PetId", "dbo.Pets");
            DropForeignKey("dbo.Pets", "PetTypeId", "dbo.PetTypes");
            DropForeignKey("dbo.PetTypes", "CoverId", "dbo.Covers");
            DropForeignKey("dbo.PetTypes", "BreedId", "dbo.Breeds");
            DropForeignKey("dbo.PetTypes", "AnimalTypeId", "dbo.AnimalTypes");
            DropForeignKey("dbo.Pets", "PersonId", "dbo.People");
            DropIndex("dbo.Vets", new[] { "VetTypeId" });
            DropIndex("dbo.Vets", new[] { "PersonId" });
            DropIndex("dbo.Visits", new[] { "ExaminationId" });
            DropIndex("dbo.Visits", new[] { "VetId" });
            DropIndex("dbo.Visits", new[] { "PetId" });
            DropIndex("dbo.Visits", new[] { "VisitTypeId" });
            DropIndex("dbo.Photos", new[] { "PetId" });
            DropIndex("dbo.PetTypes", new[] { "BreedId" });
            DropIndex("dbo.PetTypes", new[] { "CoverId" });
            DropIndex("dbo.PetTypes", new[] { "AnimalTypeId" });
            DropIndex("dbo.Pets", new[] { "PersonId" });
            DropIndex("dbo.Pets", new[] { "PetTypeId" });
            DropIndex("dbo.Examinations", new[] { "PetId" });
            DropTable("dbo.VisitTypes");
            DropTable("dbo.VetTypes");
            DropTable("dbo.Vets");
            DropTable("dbo.Visits");
            DropTable("dbo.Photos");
            DropTable("dbo.PetTypes");
            DropTable("dbo.Pets");
            DropTable("dbo.Examinations");
            DropTable("dbo.Covers");
            DropTable("dbo.Breeds");
            DropTable("dbo.AnimalTypes");
        }
    }
}

namespace ASS2_158258_2023.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CityInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TouristAttractions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CityInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CityInfoes", t => t.CityInfoId, cascadeDelete: true)
                .Index(t => t.CityInfoId);
            
            CreateTable(
                "dbo.SpecialtyFoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CityInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CityInfoes", t => t.CityInfoId, cascadeDelete: true)
                .Index(t => t.CityInfoId);
            
            CreateTable(
                "dbo.HistoryCultures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CityInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CityInfoes", t => t.CityInfoId, cascadeDelete: true)
                .Index(t => t.CityInfoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistoryCultures", "CityInfoId", "dbo.CityInfoes");
            DropForeignKey("dbo.SpecialtyFoods", "CityInfoId", "dbo.CityInfoes");
            DropForeignKey("dbo.TouristAttractions", "CityInfoId", "dbo.CityInfoes");
            DropIndex("dbo.HistoryCultures", new[] { "CityInfoId" });
            DropIndex("dbo.SpecialtyFoods", new[] { "CityInfoId" });
            DropIndex("dbo.TouristAttractions", new[] { "CityInfoId" });
            DropTable("dbo.HistoryCultures");
            DropTable("dbo.SpecialtyFoods");
            DropTable("dbo.TouristAttractions");
            DropTable("dbo.CityInfoes");
        }
    }
}

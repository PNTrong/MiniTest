namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Counties",
                c => new
                    {
                        CountyId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        ProvinceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountyId)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: false)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        BirthDay = c.DateTime(nullable: false),
                        CountyId = c.Int(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                        Avartar = c.String(maxLength: 256),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Position = c.String(),
                        Introduce = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Counties", t => t.CountyId, cascadeDelete: false)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: false)
                .Index(t => t.CountyId)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Error",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Employees", "CountyId", "dbo.Counties");
            DropForeignKey("dbo.Counties", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.Employees", new[] { "ProvinceId" });
            DropIndex("dbo.Employees", new[] { "CountyId" });
            DropIndex("dbo.Counties", new[] { "ProvinceId" });
            DropTable("dbo.Error");
            DropTable("dbo.Employees");
            DropTable("dbo.Provinces");
            DropTable("dbo.Counties");
        }
    }
}

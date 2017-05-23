namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtypetocars : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        year = c.Int(nullable: false),
                        stock = c.Int(nullable: false),
                        carType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Types", t => t.carType_Id)
                .Index(t => t.carType_Id);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        carType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "carType_Id", "dbo.Types");
            DropIndex("dbo.Cars", new[] { "carType_Id" });
            DropTable("dbo.Types");
            DropTable("dbo.Cars");
        }
    }
}

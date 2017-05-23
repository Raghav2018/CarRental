namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtypetocars1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "carType_Id", "dbo.Types");
            DropIndex("dbo.Cars", new[] { "carType_Id" });
            RenameColumn(table: "dbo.Cars", name: "carType_Id", newName: "TypeId");
            AlterColumn("dbo.Cars", "TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "TypeId");
            AddForeignKey("dbo.Cars", "TypeId", "dbo.Types", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "TypeId", "dbo.Types");
            DropIndex("dbo.Cars", new[] { "TypeId" });
            AlterColumn("dbo.Cars", "TypeId", c => c.Int());
            RenameColumn(table: "dbo.Cars", name: "TypeId", newName: "carType_Id");
            CreateIndex("dbo.Cars", "carType_Id");
            AddForeignKey("dbo.Cars", "carType_Id", "dbo.Types", "Id");
        }
    }
}

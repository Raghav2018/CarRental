namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecartypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Types (carType) VALUES ('Hatchback')");
            Sql("INSERT INTO Types (carType) VALUES ('Sedan')");
            Sql("INSERT INTO Types (carType) VALUES ('SUV')");
            Sql("INSERT INTO Types (carType) VALUES ('Luxury')");
            Sql("INSERT INTO Types (carType) VALUES ('Commercial')");
        }
        
        public override void Down()
        {
        }
    }
}

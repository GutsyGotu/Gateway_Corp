namespace SBS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInitialDbs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        MechanicId = c.Int(),
                        VehicleId = c.Int(nullable: false),
                        BookingStart = c.DateTime(nullable: false),
                        BookingEnd = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .ForeignKey("dbo.Mechanics", t => t.MechanicId)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.CustomerId)
                .Index(t => t.MechanicId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerNo = c.Int(nullable: false),
                        Name = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Email = c.String(),
                        Contact = c.String(),
                        HomeContact = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LicensePlate = c.String(),
                        Make = c.String(),
                        Model = c.String(),
                        ChasisNo = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Mechanics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MechanicNo = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Time = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dealers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DealerNo = c.Int(nullable: false),
                        Name = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Email = c.String(),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Bookings", "MechanicId", "dbo.Mechanics");
            DropForeignKey("dbo.Vehicles", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Bookings", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Vehicles", new[] { "Customer_Id" });
            DropIndex("dbo.Bookings", new[] { "VehicleId" });
            DropIndex("dbo.Bookings", new[] { "MechanicId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropIndex("dbo.Bookings", new[] { "ServiceId" });
            DropTable("dbo.Dealers");
            DropTable("dbo.Services");
            DropTable("dbo.Mechanics");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Customers");
            DropTable("dbo.Bookings");
        }
    }
}

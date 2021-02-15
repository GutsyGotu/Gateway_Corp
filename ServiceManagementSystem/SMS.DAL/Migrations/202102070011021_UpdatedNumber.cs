namespace SBS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedNumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CustomerNo", c => c.String());
            AlterColumn("dbo.Mechanics", "MechanicNo", c => c.String());
            AlterColumn("dbo.Dealers", "DealerNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dealers", "DealerNo", c => c.Int(nullable: false));
            AlterColumn("dbo.Mechanics", "MechanicNo", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "CustomerNo", c => c.Int(nullable: false));
        }
    }
}

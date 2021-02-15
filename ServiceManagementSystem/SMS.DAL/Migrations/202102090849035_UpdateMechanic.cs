namespace SBS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMechanic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mechanics", "Make", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mechanics", "Make");
        }
    }
}

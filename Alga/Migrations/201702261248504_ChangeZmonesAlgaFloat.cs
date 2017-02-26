namespace Alga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeZmonesAlgaFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Asmuos", "AlgaNet", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Asmuos", "AlgaNet", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}

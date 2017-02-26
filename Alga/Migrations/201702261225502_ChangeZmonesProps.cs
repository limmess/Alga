namespace Alga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeZmonesProps : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Asmuos", "Vardas", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Asmuos", "Pavarde", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Asmuos", "AlgaNet", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Asmuos", "AlgaNet", c => c.Int(nullable: false));
            AlterColumn("dbo.Asmuos", "Pavarde", c => c.String());
            AlterColumn("dbo.Asmuos", "Vardas", c => c.String());
        }
    }
}

namespace Alga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuginaVaikusVienas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asmuos", "AuginaVaikusVienas", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Asmuos", "AuginaVaikusVienas");
        }
    }
}

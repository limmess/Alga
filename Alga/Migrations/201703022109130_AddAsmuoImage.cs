namespace Alga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAsmuoImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asmuos", "AsmuoImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Asmuos", "AsmuoImage");
        }
    }
}

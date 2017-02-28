namespace Alga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVaikuSkaicius : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asmuos", "VaikuSkaicius", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Asmuos", "VaikuSkaicius");
        }
    }
}

namespace TicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kasas", "Tutar", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kasas", "Tutar");
        }
    }
}

namespace TicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Faturas", "Fiyat");
            DropColumn("dbo.Faturas", "Miktar");
            DropColumn("dbo.Faturas", "MiktarCins");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Faturas", "MiktarCins", c => c.String());
            AddColumn("dbo.Faturas", "Miktar", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Faturas", "Fiyat", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}

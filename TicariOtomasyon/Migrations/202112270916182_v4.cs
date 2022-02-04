namespace TicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Giders", "Tarih", c => c.DateTime(nullable: false));
            AddColumn("dbo.Giders", "Tutar", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Giders", "Elektrik");
            DropColumn("dbo.Giders", "Su");
            DropColumn("dbo.Giders", "Dogalgaz");
            DropColumn("dbo.Giders", "Internet");
            DropColumn("dbo.Giders", "Maas");
            DropColumn("dbo.Giders", "Extra");
            DropColumn("dbo.Giders", "Ay");
            DropColumn("dbo.Giders", "Yil");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Giders", "Yil", c => c.Int(nullable: false));
            AddColumn("dbo.Giders", "Ay", c => c.String());
            AddColumn("dbo.Giders", "Extra", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Giders", "Maas", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Giders", "Internet", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Giders", "Dogalgaz", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Giders", "Su", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Giders", "Elektrik", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Giders", "Tutar");
            DropColumn("dbo.Giders", "Tarih");
        }
    }
}

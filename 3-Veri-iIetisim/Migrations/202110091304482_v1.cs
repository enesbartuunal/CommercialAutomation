namespace _3_Veri_iIetisim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bankas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IBAN = c.Int(nullable: false),
                        FirmaId = c.Int(nullable: false),
                        MusteriId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Firmas", t => t.FirmaId, cascadeDelete: true)
                .ForeignKey("dbo.Musteris", t => t.MusteriId, cascadeDelete: true)
                .Index(t => t.FirmaId)
                .Index(t => t.MusteriId);
            
            CreateTable(
                "dbo.Firmas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        YetkiliStatu = c.String(),
                        YetkiliAdSoyad = c.String(),
                        Tel = c.String(),
                        Tel2 = c.String(),
                        Tel3 = c.Int(nullable: false),
                        Email = c.String(),
                        Fax = c.Int(nullable: false),
                        Il = c.String(),
                        Ilce = c.String(),
                        Adres = c.String(),
                        VergiDairesi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Musteris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        Tel = c.String(),
                        Tel2 = c.String(),
                        Tc = c.Int(nullable: false),
                        Email = c.String(),
                        Il = c.String(),
                        Ilce = c.String(),
                        Adres = c.String(),
                        VergiDairesi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FaturaBasliks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Seri = c.String(),
                        SıraNo = c.Int(nullable: false),
                        Tarih = c.String(),
                        Saat = c.String(),
                        VergiDairesi = c.String(),
                        Alici = c.String(),
                        TeslimAlan = c.String(),
                        TeslimEden = c.String(),
                        KasaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kasas", t => t.KasaId, cascadeDelete: true)
                .Index(t => t.KasaId);
            
            CreateTable(
                "dbo.Kasas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FaturaDetays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Miktar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MiktarCins = c.String(),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KasaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kasas", t => t.KasaId, cascadeDelete: true)
                .Index(t => t.KasaId);
            
            CreateTable(
                "dbo.FaturaDetayUruns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FaturaDetayId = c.Int(nullable: false),
                        UrunId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FaturaDetays", t => t.FaturaDetayId, cascadeDelete: true)
                .ForeignKey("dbo.Uruns", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.FaturaDetayId)
                .Index(t => t.UrunId);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(),
                        Marka = c.String(),
                        Model = c.String(),
                        Adet = c.Int(nullable: false),
                        AlisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SatisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Detay = c.String(),
                        StokId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stoks", t => t.StokId, cascadeDelete: true)
                .Index(t => t.StokId);
            
            CreateTable(
                "dbo.Stoks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Miktar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StoklamaCinsi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Giders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Elektrik = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Su = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Dogalgaz = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Internet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Maas = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Extra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notlar = c.String(),
                        Ay = c.String(),
                        Yil = c.Int(nullable: false),
                        KasaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kasas", t => t.KasaId, cascadeDelete: true)
                .Index(t => t.KasaId);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        Tel = c.String(),
                        Tc = c.Int(nullable: false),
                        Email = c.String(),
                        Görev = c.String(),
                        Il = c.String(),
                        Ilce = c.String(),
                        Adres = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Giders", "KasaId", "dbo.Kasas");
            DropForeignKey("dbo.FaturaDetays", "KasaId", "dbo.Kasas");
            DropForeignKey("dbo.Uruns", "StokId", "dbo.Stoks");
            DropForeignKey("dbo.FaturaDetayUruns", "UrunId", "dbo.Uruns");
            DropForeignKey("dbo.FaturaDetayUruns", "FaturaDetayId", "dbo.FaturaDetays");
            DropForeignKey("dbo.FaturaBasliks", "KasaId", "dbo.Kasas");
            DropForeignKey("dbo.Bankas", "MusteriId", "dbo.Musteris");
            DropForeignKey("dbo.Bankas", "FirmaId", "dbo.Firmas");
            DropIndex("dbo.Giders", new[] { "KasaId" });
            DropIndex("dbo.Uruns", new[] { "StokId" });
            DropIndex("dbo.FaturaDetayUruns", new[] { "UrunId" });
            DropIndex("dbo.FaturaDetayUruns", new[] { "FaturaDetayId" });
            DropIndex("dbo.FaturaDetays", new[] { "KasaId" });
            DropIndex("dbo.FaturaBasliks", new[] { "KasaId" });
            DropIndex("dbo.Bankas", new[] { "MusteriId" });
            DropIndex("dbo.Bankas", new[] { "FirmaId" });
            DropTable("dbo.Personels");
            DropTable("dbo.Giders");
            DropTable("dbo.Stoks");
            DropTable("dbo.Uruns");
            DropTable("dbo.FaturaDetayUruns");
            DropTable("dbo.FaturaDetays");
            DropTable("dbo.Kasas");
            DropTable("dbo.FaturaBasliks");
            DropTable("dbo.Musteris");
            DropTable("dbo.Firmas");
            DropTable("dbo.Bankas");
        }
    }
}

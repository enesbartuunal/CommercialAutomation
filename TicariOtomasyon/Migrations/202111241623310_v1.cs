namespace TicariOtomasyon.Migrations
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
                        IBAN = c.String(nullable: false),
                        FirmaId = c.Int(),
                        MusteriId = c.Int(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Firmas", t => t.FirmaId)
                .ForeignKey("dbo.Musteris", t => t.MusteriId)
                .Index(t => t.FirmaId)
                .Index(t => t.MusteriId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        KasaId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kasas", t => t.KasaId, cascadeDelete: true)
                .Index(t => t.KasaId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.FaturaKalems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Miktar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UrunId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Uruns", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.UrunId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.FaturaKalemOrtaks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FaturaId = c.Int(nullable: false),
                        FaturaKalemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faturas", t => t.FaturaId, cascadeDelete: true)
                .ForeignKey("dbo.FaturaKalems", t => t.FaturaKalemId, cascadeDelete: true)
                .Index(t => t.FaturaId)
                .Index(t => t.FaturaKalemId);
            
            CreateTable(
                "dbo.Faturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Seri = c.String(),
                        SıraNo = c.Int(nullable: false),
                        TarihSaat = c.DateTime(nullable: false),
                        VergiDairesi = c.String(),
                        Alici = c.String(),
                        TeslimAlan = c.String(),
                        TeslimEden = c.String(),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Miktar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MiktarCins = c.String(),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KasaId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Kasas", t => t.KasaId, cascadeDelete: true)
                .Index(t => t.KasaId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Kasas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Kasas", t => t.KasaId, cascadeDelete: true)
                .Index(t => t.KasaId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(),
                        Marka = c.String(),
                        Model = c.String(),
                        AlisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SatisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Detay = c.String(),
                        StoklamaCinsi = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
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
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
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
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Stoks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Miktar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UrunId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Uruns", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.UrunId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Bankas", "MusteriId", "dbo.Musteris");
            DropForeignKey("dbo.Bankas", "FirmaId", "dbo.Firmas");
            DropForeignKey("dbo.Stoks", "UrunId", "dbo.Uruns");
            DropForeignKey("dbo.Stoks", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Personels", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Musteris", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "KasaId", "dbo.Kasas");
            DropForeignKey("dbo.Firmas", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FaturaKalems", "UrunId", "dbo.Uruns");
            DropForeignKey("dbo.Uruns", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FaturaKalemOrtaks", "FaturaKalemId", "dbo.FaturaKalems");
            DropForeignKey("dbo.Giders", "KasaId", "dbo.Kasas");
            DropForeignKey("dbo.Giders", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Faturas", "KasaId", "dbo.Kasas");
            DropForeignKey("dbo.FaturaKalemOrtaks", "FaturaId", "dbo.Faturas");
            DropForeignKey("dbo.Faturas", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FaturaKalems", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bankas", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Stoks", new[] { "ApplicationUserId" });
            DropIndex("dbo.Stoks", new[] { "UrunId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Personels", new[] { "ApplicationUserId" });
            DropIndex("dbo.Musteris", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Firmas", new[] { "ApplicationUserId" });
            DropIndex("dbo.Uruns", new[] { "ApplicationUserId" });
            DropIndex("dbo.Giders", new[] { "ApplicationUserId" });
            DropIndex("dbo.Giders", new[] { "KasaId" });
            DropIndex("dbo.Faturas", new[] { "ApplicationUserId" });
            DropIndex("dbo.Faturas", new[] { "KasaId" });
            DropIndex("dbo.FaturaKalemOrtaks", new[] { "FaturaKalemId" });
            DropIndex("dbo.FaturaKalemOrtaks", new[] { "FaturaId" });
            DropIndex("dbo.FaturaKalems", new[] { "ApplicationUserId" });
            DropIndex("dbo.FaturaKalems", new[] { "UrunId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "KasaId" });
            DropIndex("dbo.Bankas", new[] { "ApplicationUserId" });
            DropIndex("dbo.Bankas", new[] { "MusteriId" });
            DropIndex("dbo.Bankas", new[] { "FirmaId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Stoks");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Personels");
            DropTable("dbo.Musteris");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Firmas");
            DropTable("dbo.Uruns");
            DropTable("dbo.Giders");
            DropTable("dbo.Kasas");
            DropTable("dbo.Faturas");
            DropTable("dbo.FaturaKalemOrtaks");
            DropTable("dbo.FaturaKalems");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Bankas");
        }
    }
}

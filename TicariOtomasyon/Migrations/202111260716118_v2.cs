namespace TicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FaturaKalems", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FaturaKalemOrtaks", "FaturaId", "dbo.Faturas");
            DropForeignKey("dbo.FaturaKalemOrtaks", "FaturaKalemId", "dbo.FaturaKalems");
            DropForeignKey("dbo.FaturaKalems", "UrunId", "dbo.Uruns");
            DropIndex("dbo.FaturaKalems", new[] { "UrunId" });
            DropIndex("dbo.FaturaKalems", new[] { "ApplicationUserId" });
            DropIndex("dbo.FaturaKalemOrtaks", new[] { "FaturaId" });
            DropIndex("dbo.FaturaKalemOrtaks", new[] { "FaturaKalemId" });
            DropTable("dbo.FaturaKalems");
            DropTable("dbo.FaturaKalemOrtaks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FaturaKalemOrtaks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FaturaId = c.Int(nullable: false),
                        FaturaKalemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FaturaKalems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Miktar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UrunId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.FaturaKalemOrtaks", "FaturaKalemId");
            CreateIndex("dbo.FaturaKalemOrtaks", "FaturaId");
            CreateIndex("dbo.FaturaKalems", "ApplicationUserId");
            CreateIndex("dbo.FaturaKalems", "UrunId");
            AddForeignKey("dbo.FaturaKalems", "UrunId", "dbo.Uruns", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FaturaKalemOrtaks", "FaturaKalemId", "dbo.FaturaKalems", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FaturaKalemOrtaks", "FaturaId", "dbo.Faturas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FaturaKalems", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}

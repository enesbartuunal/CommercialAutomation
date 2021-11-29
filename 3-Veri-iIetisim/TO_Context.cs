using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeriTabani;

namespace _3_Veri_iIetisim
{
    public class TO_Context : DbContext
    {
        public TO_Context() : base(Config.connectionString)
        {

        }

        public DbSet<Banka> Bankas { get; set; }
        public DbSet<FaturaBaslik> FaturaBasliks { get; set; }
        public DbSet<FaturaDetay> FaturaDetays { get; set; }
        public DbSet<FaturaDetayUrun> FaturaDetayUruns { get; set; }
        public DbSet<Firma> Firmas { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<Kasa> Kasas { get; set; }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Stok> Stoks { get; set; }
        public DbSet<Urun> Uruns { get; set; }

    }
}

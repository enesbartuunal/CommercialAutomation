using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriTabani
{
     public class FaturaDetay
    {
        public int Id { get; set; }

        public string UrunAd { get; set; }

        public decimal Fiyat { get; set; }

        public decimal Miktar { get; set; }

        public string MiktarCins { get; set; }

        public decimal Tutar { get; set; }

        public List<FaturaDetayUrun> FaturaDetayUruns { get; set; }

        public int KasaId { get; set; }

        public virtual Kasa Kasa { get; set; }

    }
}


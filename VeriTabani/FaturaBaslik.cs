using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriTabani
{
    public class FaturaBaslik
    {
        public int Id { get; set; }

        public string Seri { get; set; }

        public int SıraNo { get; set; }

        public string Tarih { get; set; }

        public string Saat { get; set; }

        public string VergiDairesi { get; set; }

        public string Alici { get; set; }

        public string TeslimAlan { get; set; }

        public string TeslimEden { get; set; }

        public int KasaId { get; set; }

        public virtual Kasa Kasa { get; set; }

    }
}

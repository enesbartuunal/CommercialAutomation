using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriTabani
{
    public class Gider
    {
        public int Id { get; set; }

        public decimal Elektrik{ get; set; }

        public decimal Su { get; set; }

        public decimal Dogalgaz { get; set; }

        public decimal Internet { get; set; }

        public decimal Maas { get; set; }

        public decimal Extra { get; set; }

        public string Notlar { get; set; }

        public string Ay { get; set; }

        public int Yil { get; set; }

        public int KasaId { get; set; }

        public virtual Kasa Kasa { get; set; }
    }
}

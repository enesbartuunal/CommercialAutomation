using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriTabani
{
     public class Stok
    {
        public int Id { get; set; }

        public decimal Miktar { get; set; }

        public string StoklamaCinsi { get; set; }

        public List<Urun> Urunler { get; set; }


    }
}

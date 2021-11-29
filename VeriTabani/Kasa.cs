using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriTabani
{
    public class Kasa
    {
        public int Id { get; set; }

        public List<Gider> Giders { get; set; }

        public List<FaturaBaslik> FaturaBasliks { get; set; }

        public List<FaturaDetay> FaturaDetays { get; set; }

    }
}

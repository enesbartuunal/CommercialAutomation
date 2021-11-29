using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriTabani
{
    public class FaturaDetayUrun
    {
        public int Id { get; set; }

        public  int FaturaDetayId { get; set; }

        public virtual FaturaDetay FaturaDetay{ get; set; }

        public  int UrunId { get; set; }

        public virtual Urun Urun { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriTabani
{
    public class Banka
    {
        public int Id { get; set; }

        public int IBAN { get; set; }

        public int FirmaId { get; set; }

        public virtual Firma Firma { get; set; }

        public int MusteriId { get; set; }

        public virtual Musteri Musteri { get; set; }

        
    }
}

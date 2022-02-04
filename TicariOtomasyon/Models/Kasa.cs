using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicariOtomasyon.Models
{
    public class Kasa
    {
        public int Id { get; set; }

        public DateTime Tarih { get; set; }

        public decimal Tutar { get; set; }

        public List<Gider> Giders { get; set; }

        public List<Fatura> FaturaBasliks { get; set; }

        

       
    }
}

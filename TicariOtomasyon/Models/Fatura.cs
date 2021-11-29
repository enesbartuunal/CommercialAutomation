using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicariOtomasyon.Models
{
    public class Fatura
    {
        public int Id { get; set; }

        public string Seri { get; set; }

        public int SıraNo { get; set; }

        public DateTime TarihSaat { get; set; }

        public string VergiDairesi { get; set; }

        public string Alici { get; set; }

        public string TeslimAlan { get; set; }

        public string TeslimEden { get; set; }

        public decimal Fiyat { get; set; }

        public decimal Miktar { get; set; }

        public string MiktarCins { get; set; }

        public decimal Tutar { get; set; }

        public int KasaId { get; set; }

        public virtual Kasa Kasa { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}

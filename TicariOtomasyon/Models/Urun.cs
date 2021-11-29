using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicariOtomasyon.Models
{
    public class Urun
    {
        public int Id { get; set; }

        public string UrunAd { get; set; }

        public string Marka { get; set; }

        public string Model { get; set; }

        public char Yil { get; set; }

        public decimal AlisFiyat { get; set; }

        public decimal SatisFiyat { get; set; }

        public string Detay { get; set; }

        public string StoklamaCinsi { get; set; }
               
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}

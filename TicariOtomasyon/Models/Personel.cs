using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicariOtomasyon.Models
{
     public class Personel
    {
        public int Id { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Tel { get; set; }

        public  int Tc { get; set; }

        public string Email { get; set; }

        public string Görev { get; set; }

        public string Il { get; set; }

        public string Ilce { get; set; }

        public string Adres { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicariOtomasyon.Models
{
    public class Firma
    {
        public int Id { get; set; }

        public string Ad { get; set; }

        public string YetkiliStatu { get; set; }

        public string YetkiliAdSoyad { get; set; }

        public string Tel { get; set; }

        public string Tel2 { get; set; }

        public int Tel3 { get; set; }

        public string Email { get; set; }

        public int Fax { get; set; }

        public string Il { get; set; }

        public string Ilce { get; set; }

        public string Adres { get; set; }

        public string VergiDairesi { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }


    }
}

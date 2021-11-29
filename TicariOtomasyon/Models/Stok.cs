using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicariOtomasyon.Models
{
    public class Stok
    {
        public int Id { get; set; }
               
        public decimal Miktar { get; set; }

        public int UrunId { get; set; }

        public Urun Urun { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}

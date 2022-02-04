using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicariOtomasyon.Models
{
    public class Gider
    {
        public int Id { get; set; }

        public DateTime Tarih { get; set; }

        public string Notlar { get; set; }

        public decimal Tutar { get; set; }

        public int KasaId { get; set; }

        public virtual Kasa Kasa { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}

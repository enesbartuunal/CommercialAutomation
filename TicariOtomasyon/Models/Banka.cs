using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicariOtomasyon.Models
{
    public class Banka
    {
        public int Id { get; set; }

        [Required]
        public string IBAN { get; set; }

        public int? FirmaId { get; set; }

        public virtual Firma Firma { get; set; }

        public int? MusteriId { get; set; }

        public virtual Musteri Musteri { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}

using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace TicariOtomasyon.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public List<Banka> Bankas { get; set; }
        public List<Fatura> Faturas { get; set; }
        public List<Firma> Firmas { get; set; }
        public List<Gider> Giders { get; set; }
        public int KasaId { get; set; }
        public virtual Kasa Kasa { get; set; }
        public List<Musteri> Musteris { get; set; }
        public List<Personel> Personels { get; set; }
        public List<Stok> Stoks { get; set; }
        public List<Urun> Uruns { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }


    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("TO_Connection", throwIfV1Schema: false)
        {

        }
        public DbSet<Banka> Bankas { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Firma> Firmas { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<Kasa> Kasas { get; set; }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Stok> Stoks { get; set; }
        public DbSet<Urun> Uruns { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }




    }
}
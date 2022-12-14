using Microsoft.EntityFrameworkCore;

namespace KD12MVCHamburger.Data
{
    public class HamburgerDbContext : DbContext
    {
        public HamburgerDbContext(DbContextOptions<HamburgerDbContext> options) : base(options)
        {

        }

        public DbSet<Menu> Menuler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Ekstra> Ekstralar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>().HasData(
                new Menu() {Id=1,MenuAd = "Whopper", Fiyat = 45 },
                new Menu() {Id=2,MenuAd = "Double Whopper", Fiyat = 60 },
                new Menu() {Id=3,MenuAd = "Double Köfte Burger", Fiyat = 65 },
                new Menu() {Id=4,MenuAd = "Cheeseburger", Fiyat = 55 }
                );

            modelBuilder.Entity<Ekstra>().HasData(
                new Ekstra() { Id=1,EkstraAdı="Ketçap",Fiyat=2},
                new Ekstra() { Id=2,EkstraAdı="Mayonez",Fiyat=4},
                new Ekstra() { Id=3,EkstraAdı="Ranch",Fiyat=8}
            );
        }


    }
}

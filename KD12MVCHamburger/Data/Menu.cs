namespace KD12MVCHamburger.Data
{
    public class Menu
    {
        public int Id { get; set; }
        public string MenuAd { get; set; }
        public decimal Fiyat { get; set; }
        public string MenuFiyat => MenuAd + " - " + Fiyat + "₺"; 
    }
}

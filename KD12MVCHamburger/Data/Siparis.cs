namespace KD12MVCHamburger.Data
{
    public class Siparis
    {
        public int Id { get; set; }
        public string Boyut { get; set; }
        public int Adet { get; set; }
        public decimal ToplamTutar { get; set; }
        public string Ekstralar { get; set; }
        public int MenuId { get; set; }
        public Menu SecilenMenu { get; set; }
        public bool AktifMi { get; set; } = true;

        public decimal ToplamTutarHesapla(string boyut)
        {
            decimal toplamTutar = 0;
            if (boyut == "Küçük")
                toplamTutar = SecilenMenu.Fiyat;
            if (boyut == "Orta")
                toplamTutar = (SecilenMenu.Fiyat / 10) + SecilenMenu.Fiyat;
            if (boyut == "Büyük")
                toplamTutar = (SecilenMenu.Fiyat / 4) + SecilenMenu.Fiyat;

            return toplamTutar * Adet;
        }


    }
}

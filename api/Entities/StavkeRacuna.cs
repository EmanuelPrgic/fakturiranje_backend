namespace api.Entities
{
    public class StavkeRacuna
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public int Kolicina { get; set; }
        public decimal CijenaDeviza { get; set; }
        public decimal CijenaKM { get; set; }
        public decimal FakturnaVrijednost { get; set; }
        public decimal Rabat { get; set; }
        public decimal IznosRabata { get; set; }
        public decimal Pdv { get; set; }
        public decimal Osnovica { get; set; }
        public decimal IznosPdv { get; set; }
        public decimal UkupanIznos { get; set; }
        public int BrojRacuna { get; set; }

        public ZaglavljeRacuna ZaglavljeRacuna { get; set; } = null!;
    }
}
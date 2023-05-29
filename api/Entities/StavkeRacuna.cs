namespace api.Entities
{
    public class StavkeRacuna
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public int Kolicina { get; set; }
        public int CijenaDeviza { get; set; }
        public int CijenaKM { get; set; }
        public int Rabat { get; set; }
        public int Pdv { get; set; }
        public int BrojRacuna { get; set; }

        public ZaglavljeRacuna ZaglavljeRacuna { get; set; } = null!;
    }
}
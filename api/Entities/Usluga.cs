namespace api.Entities
{
    public class Usluga
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int CijenaDeviza { get; set; }
        public int CijenaKM { get; set; }
        public int StavkeRacunaId { get; set; }

        public StavkeRacuna StavkeRacuna { get; set;}
    }
}
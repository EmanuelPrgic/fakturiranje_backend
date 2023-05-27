using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class StavkeRacunaDto
    {
        public int Id { get; set; }
        [Required]
        public string Opis { get; set; }
        [Required]
        public int Kolicina { get; set; }
        [Required]
        public int Cijenadeviza { get; set; }
        public int Fakturnavrijednost { get; set; }
        public int Rabat { get; set; }
        public int Iznosrabata { get; set; }
        public int Pdv { get; set; }
        public int Osnovica { get; set; }
        public int Iznospdv { get; set; }
        public int Ukupaniznos { get; set; }
        public int Brojracuna { get; set; }
    }
}
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
        public decimal Cijenadeviza { get; set; }
        public decimal Cijenakm { get; set; }
        public decimal Fakturnavrijednost { get; set; }
        public decimal Rabat { get; set; }
        public decimal Iznosrabata { get; set; }
        public decimal Pdv { get; set; }
        public decimal Osnovica { get; set; }
        public decimal Iznospdv { get; set; }
        public decimal Ukupaniznos { get; set; }
        public int Brojracuna { get; set; }
    }
}